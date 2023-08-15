using Domain.ContractEntity;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using sureApp.Infrastructure;

namespace Infrastructure.ContractSource
{
    public class ContractConfig : ICommand
    {
        public Task PreInitializator(ApplicationDbContext context, CreateAutoincrementalEntitys counter)
        {
            return Task.CompletedTask;
        }

        public void ToMap()
        {
            BsonClassMap.RegisterClassMap<Contract>(classMap =>
            {
                classMap.MapIdMember(x => x.Id).SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                classMap.AutoMap();
            });
        }
    }
}
