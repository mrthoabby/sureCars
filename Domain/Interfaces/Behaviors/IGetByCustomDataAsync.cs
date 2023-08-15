namespace sureApp.domain.Interfaces.Behaviors
{
    public interface IGetByCustomDataAsync<Entity, EntityCustomSearcherData> where Entity : class
    {
        Task<Entity> GetByCustomDataSearcher(EntityCustomSearcherData data);
    }
}
