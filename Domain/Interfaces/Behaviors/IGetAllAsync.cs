namespace sureApp.domain.Interfaces.Behaviors
{
    public interface IGetAllAsync<Entity> where Entity : class
    {
        Task<IQueryable<Entity>> GetAllAsync();

    }
}
