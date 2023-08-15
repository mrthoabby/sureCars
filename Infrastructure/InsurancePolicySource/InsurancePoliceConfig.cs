using Infrastructure.CoverageFeatureSource;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using MongoDB.Bson.Serialization;
using sureApp.domain.ValueObjects;
using sureApp.Infrastructure;
using sureApp.Infrastructure.InsurancePolicySource;
using Domain.InsurancePolicyEntity;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Infrastructure.InsurancePolicySource
{
    internal class InsurancePolicyConfig
        :ICommand
    {
        public async Task PreInitializator(ApplicationDbContext context, CreateAutoincrementalEntitys counter)
        {
            //var insuranceFeatures = new List<int>();

            var repo = new CoverageFeatureRepository(context, counter); 
            var coverageRepo = new InsurancePolicyRepository(context, counter);
            var entities = await coverageRepo.GetAllAsync();
            if (entities.Count() > 0)
            {
                return;
            }
            var coverages = await repo.GetAllAsync();
            var suresPolicys = new List<string>() {
                "Protección TotalShield",
                "Seguro SerenidadPlus",
                "Cobertura Segura360",
                "Tranquilidad TotalCare",
                "Respaldo SeguroLife"
            };
            for(int incrementator = 0; incrementator < suresPolicys.Count; incrementator++)
            {
                var insuranceFeatures = new List<int>();
                foreach (var coverage in coverages)
                {
                    if (new Random().Next(1, 11) % 2 == 0)
                    {
                        insuranceFeatures.Add(coverage.Id);
                    }
                }
                var entity = new InsurancePolicy
                {
                    FeaturesId = insuranceFeatures,
                    MaximunCoverageValue = new Random().Next(1000000, 30000000),
                    Name = suresPolicys[incrementator],
                    Validity = new DateRange(DateTime.Now, DateTime.Now.AddMinutes(new Random().Next(1, 3)))
                };

                await coverageRepo.CreateAsync(entity);
            }
        }

        public void ToMap()
        {
            BsonClassMap.RegisterClassMap<InsurancePolicy>(classMap =>
            {
                classMap.MapIdMember(x => x.Identifier).SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                classMap.AutoMap();
            });
        }

       
    }
}
