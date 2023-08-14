
using Application.VSCoverage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sureApp.Infrastructure.CoverageSource;
using sureApp.domain.CoverageEntity;
using Infrastructure.Helpers;
using Infrastructure.CoverageSource;
using Infrastructure.CoverageFeatureSource;

namespace sureApp.Infrastructure
{
    public static class DependecyInjection
    {
        public static bool IsEnviromentDev = true;
        private static CreateAutoincrementalEntitys autoIndexDb;
        private static ApplicationDbContext dbContext;

        public static async Task<IServiceCollection> AddInfraestructureInDevMode(this
            IServiceCollection services, IConfiguration configuration)
        {
            IsEnviromentDev = configuration["Enviroment"] != "production";
            if (IsEnviromentDev)
            {
                var autoIndexDb = new CreateAutoincrementalEntitys(dbContext);
                await Configurator.ExecutePreInitializator(dbContext, autoIndexDb);
            }
            return services;

        }
            public static IServiceCollection AddInfrastructure(this
            IServiceCollection services, IConfiguration configuration)
        {
            Configurator.AddObject(new CoverageFeatureConfig());
            Configurator.AddObject(new CoverageConfigs());
            Configurator.ExecuteMapping();

            var connectionString = configuration.GetConnectionString("MongoDbConnectionString");
            var databaseName = configuration.GetConnectionString("MongoDatabaseName");
           
            if (connectionString is null || databaseName is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            dbContext = new ApplicationDbContext(connectionString, databaseName);
            _ = services.AddScoped(
                  provider => dbContext);
            services.AddScoped<ICoverageRepository, CoverageRepository>();
            services.AddScoped<ICoverageServices, CoverageServices>();

            autoIndexDb = new CreateAutoincrementalEntitys(dbContext);
            services.AddSingleton(provider => autoIndexDb);
            
            return services;
        }

    }
}
