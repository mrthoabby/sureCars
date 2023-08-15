using Domain.CoverageFeatureEntity;
using Infrastructure.Helpers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using sureApp.domain.CoverageFeatureEntity;
using sureApp.Infrastructure;

namespace Infrastructure.CoverageFeatureSource
{
    public class CoverageFeatureRepository : ICoverageFeatureRepository
    {
        private readonly IMongoCollection<CoverageFeature> _collection;
        private readonly CreateAutoincrementalEntitys _autoIncrementer;
        public CoverageFeatureRepository(ApplicationDbContext context, CreateAutoincrementalEntitys autoIncrementer)
        {
            _collection = context.CoverageFeatures;
            _autoIncrementer = autoIncrementer;
        }
        public async Task<CoverageFeature> CreateAsync(CoverageFeature entity)
        {
            return await _autoIncrementer.CreateWithAutoIncrementId(entity, _collection);
        }

        public async Task<IQueryable<CoverageFeature>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }

        public async Task<CoverageFeature> GetByIdAsync(long id)
        {
            var data = _collection.AsQueryable();
            return await data.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
