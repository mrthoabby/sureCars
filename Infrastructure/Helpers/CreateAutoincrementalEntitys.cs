using MongoDB.Driver;
using sureApp.Infrastructure;
using System.Reflection;

namespace Infrastructure.Helpers
{
    public class CreateAutoincrementalEntitys
    {

        private readonly IMongoCollection<CounterAutoIncremental> _counter;
        public CreateAutoincrementalEntitys(ApplicationDbContext context)
        {
            _counter = context.Counters;
        }
        public async Task<Entity> CreateWithAutoIncrementId<Entity>(Entity entity,IMongoCollection<Entity> _collection)
        {
            var filter = Builders<CounterAutoIncremental>.Filter.Eq(x => x.Identifier, typeof(Entity).Name);
            var update = Builders<CounterAutoIncremental>.Update.Inc(x => x.currentCounterValue, 1);
            var options = new FindOneAndUpdateOptions<CounterAutoIncremental>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            try
            {
                var currentId = await _counter.FindOneAndUpdateAsync(filter, update, options);
                PropertyInfo idProperty = typeof(Entity).GetProperty("Id");
                if (idProperty != null && currentId != null)
                {
                    idProperty.SetValue(entity, currentId.currentCounterValue);
                }
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                //Por ahora no manejaré las execiones por cuestion de tiempo
            }
            return entity;
        }
    }
}
