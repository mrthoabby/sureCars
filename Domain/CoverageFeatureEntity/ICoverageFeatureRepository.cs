using sureApp.domain.CoverageFeatureEntity;
using sureApp.domain.Interfaces.Behaviors;

namespace Domain.CoverageFeatureEntity
{
    public interface ICoverageFeatureRepository:ICreateAsync<CoverageFeature>, IGetAllAsync<CoverageFeature>
    {
    }
}
