
using Application.VSCoverage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sureApp.Infrastructure.CoverageSource;
using sureApp.domain.CoverageEntity;
using Infrastructure.Helpers;
using Infrastructure.CoverageSource;

namespace sureApp.Infrastructure
{
    public static class DependecyInjection
    {
        public static async Task<IServiceCollection> AddInfrastructure(this
            IServiceCollection services, IConfiguration configuration)
        {
            Configurator.AddObject(new CoverageConfigs());
            Configurator.ExecuteMapping();

            var connectionString = configuration.GetConnectionString("MongoDbConnectionString");
            var databaseName = configuration.GetConnectionString("MongoDatabaseName");
            var dbContext = new ApplicationDbContext(connectionString, databaseName);
            if (connectionString is null || databaseName is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            _ = services.AddScoped(
                  provider => dbContext);
            services.AddScoped<ICoverageRepository, CoverageRepository>();
            services.AddScoped<ICoverageServices, CoverageServices>();
            await Configurator.ExecutePreInitializator(dbContext);
            return services;
        }

    }
}
