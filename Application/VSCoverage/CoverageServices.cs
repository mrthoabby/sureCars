using sureApp.domain.CoverageEntity;

namespace Application.VSCoverage
{
    public class CoverageServices : ICoverageServices
    {
        private ICoverageRepository _coverageRepository;
        public CoverageServices(ICoverageRepository coverageRepository)
        {
            _coverageRepository = coverageRepository;
        }

        public Task<Coverage> CreateAsync(Coverage entity)
        {
           return _coverageRepository.CreateAsync(entity);
        }

        public async Task<IQueryable<Coverage>> GetAllAsync()
        {
            return await _coverageRepository.GetAllAsync();
        }
    }
}
