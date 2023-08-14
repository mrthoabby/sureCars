using Infrastructure.Helpers;
using MongoDB.Driver;
using sureApp.domain.CoverageEntity;
using sureApp.domain.CoverageFeatureEntity;

namespace sureApp.Infrastructure
{
    public class ApplicationDbContext
    {
        public IMongoCollection<Coverage> Coverages { get; private init; }
        public IMongoCollection<CoverageFeature> CoverageFeatures { get; private init; }
        public IMongoCollection<CounterAutoIncremental> Counters { get; private init; }

        private readonly IMongoDatabase database;
        public ApplicationDbContext(string connectionString,string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            Coverages = database.GetCollection<Coverage>(nameof(Coverage));
            Counters = database.GetCollection<CounterAutoIncremental>(nameof(CounterAutoIncremental));
            CoverageFeatures = database.GetCollection<CoverageFeature>(nameof(CoverageFeature));
        }
    }
}
