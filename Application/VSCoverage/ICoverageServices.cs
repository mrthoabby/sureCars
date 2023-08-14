using sureApp.domain.CoverageEntity;
using sureApp.domain.Interfaces.Behaviors;

namespace Application.VSCoverage
{
    public interface ICoverageServices : IGetAllAsync<Coverage>,ICreateAsync<Coverage>
    {
    }
}
