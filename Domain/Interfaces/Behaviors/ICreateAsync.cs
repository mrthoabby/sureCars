
namespace sureApp.domain.Interfaces.Behaviors
{
    public interface ICreateAsync<Entity> where Entity : class
    {
        Task<Entity> CreateAsync(Entity entity);
    }
}
