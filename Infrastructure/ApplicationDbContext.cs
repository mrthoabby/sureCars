using Infrastructure.Helpers;
using MongoDB.Driver;
using sureApp.domain.CoverageFeatureEntity;
using Domain.InsurancePolicyEntity;
using sureApp.domain.CustomerEntity;
using Domain.ContractInsurancePolicyEntity;

namespace sureApp.Infrastructure
{
    public class ApplicationDbContext
    {
        public IMongoCollection<InsurancePolicy> Coverages { get; private init; }
        public IMongoCollection<CoverageFeature> CoverageFeatures { get; private init; }
        public IMongoCollection<Customer> Customers { get; private init; }
        public IMongoCollection<ContractInsurancePolicy> Contracts { get; private init; }
        public IMongoCollection<CounterAutoIncremental> Counters { get; private init; }
        

        private readonly IMongoDatabase database;
        public ApplicationDbContext(string connectionString,string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            Coverages = database.GetCollection<InsurancePolicy>(nameof(InsurancePolicy));
            Counters = database.GetCollection<CounterAutoIncremental>(nameof(CounterAutoIncremental));
            CoverageFeatures = database.GetCollection<CoverageFeature>(nameof(CoverageFeature));
            Customers = database.GetCollection<Customer>(nameof(Customer));
            Contracts = database.GetCollection<ContractInsurancePolicy>(nameof(ContractInsurancePolicy));
        }
    }
}
