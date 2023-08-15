
using Application.VSInsurancePolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sureApp.Infrastructure.InsurancePolicySource;
using Infrastructure.Helpers;
using Infrastructure.CoverageFeatureSource;
using Domain.InsurancePolicyEntity;
using Infrastructure.InsurancePolicySource;
using sureApp.Application.VSCustomer;
using Application.VSContractInsurancePolicy;
using sureApp.domain.CustomerEntity;
using Infrastructure.CustomerSource;
using Infrastructure.ContractInsurancePolicySource;
using Domain.ContractInsurancePolicyEntity;

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
            Configurator.Init();
            Configurator.AddObject(new CoverageFeatureConfig());
            Configurator.AddObject(new InsurancePolicyConfig());
            Configurator.AddObject(new CostumerConfig());
            Configurator.AddObject(new ContractInsurancePolicyConfig());
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
            services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContractInsurancePolicyRepository, ContractInsurancePolicyRepository>();


            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IContractInsurancePolicyService, ContractInsurancePolicyService>();

            autoIndexDb = new CreateAutoincrementalEntitys(dbContext);
            services.AddSingleton(provider => autoIndexDb);
            
            return services;
        }

    }
}
