using Infrastructure.Helpers;
using MongoDB.Driver;
using sureApp.domain.CoverageEntity;

namespace sureApp.Infrastructure.CoverageSource
{
    internal sealed class CoverageRepository : ICoverageRepository
    {
        private readonly IMongoCollection<Coverage> _collection;
        private readonly IMongoCollection<CounterAutoIncremental> _counter;
        public CoverageRepository(ApplicationDbContext context)
        {
            _collection = context.Coverages;
            _counter = context.Counters; 
        }

        public async Task<Coverage> CreateAsync(Coverage entity)
        {
            var filter = Builders<CounterAutoIncremental>.Filter.Eq(x => x.Identifier, nameof(Coverage));
            var update = Builders< CounterAutoIncremental>.Update.Inc(x => x.currentCounterValue, 1);
            var options = new FindOneAndUpdateOptions<CounterAutoIncremental>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            try
            {
            var currentId = await _counter.FindOneAndUpdateAsync(filter, update).ConfigureAwait(true);
            if(currentId == null) {
                throw new Exception("Invalid counter Error");
            }
            entity.Id = currentId.currentCounterValue;
            await _collection.InsertOneAsync(entity);
            }
            catch(Exception ex)
            {
                //Por ahora no manejaré las execiones por cuestion de tiempo
            }
            return entity;
        }

        public Task<IQueryable<Coverage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
