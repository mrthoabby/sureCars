using sureApp.domain.Interfaces.Behaviors;

namespace sureApp.domain.CoverageEntity
{
    public interface ICoverageRepository : ICreateAsync<Coverage>, IGetAllAsync<Coverage>
    {
    }
}
