namespace sureApp.domain.Interfaces.Behaviors
{
    internal interface IGetByCustomDataAsyncc<Entity, EntityCustomSearcherData> where Entity : class
    {
        Task<Entity> GetByCustomDataSearcher(EntityCustomSearcherData data);
    }
}
