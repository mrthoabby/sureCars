using Domain.ContractInsurancePolicyEntity;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using MongoDB.Bson.Serialization;
using sureApp.Infrastructure;

namespace Infrastructure.ContractInsurancePolicySource
{
    public class ContractInsurancePolicyConfig : ICommand
    {
        public Task PreInitializator(ApplicationDbContext context, CreateAutoincrementalEntitys counter)
        {
            return Task.CompletedTask;
        }

        public void ToMap()
        {
            BsonClassMap.RegisterClassMap<ContractInsurancePolicy>(classMap =>
            {
                classMap.MapIdMember(x => x.PolicyContractNumber);
                classMap.AutoMap();
            });
        }
    }
}
