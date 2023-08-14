using Infrastructure.Interfaces;
using MongoDB.Bson.Serialization;
using sureApp.domain.CoverageEntity;
using sureApp.domain.ValueObjects;
using sureApp.Infrastructure;
using sureApp.Infrastructure.CoverageSource;

namespace Infrastructure.CoverageSource
{
    internal class CoverageConfigs:ICommand
    {
        public async Task PreInitializator(ApplicationDbContext context)
        {
            var tasks = Enumerable.Range(0, 11).Select(incrementator =>
            {
                return Task.Run(async () =>

                {
                    var repo = new CoverageRepository(context);
                    var entity = new Coverage
                    {
                        Availability = new DateRange(DateTime.Now, DateTime.Now.AddMonths(incrementator + 1)),
                        MaximunCoverageValue = (incrementator * 10000) + 5,
                        Name = $"Coverage{incrementator}"
                    };

                    await repo.CreateAsync(entity);
                });
            }).ToArray();
            await Task.WhenAll(tasks);
        }

        public void ToMap()
        {
            BsonClassMap.RegisterClassMap<Coverage>(classMap =>
            {
                classMap.MapIdMember(x => x.Id);
                classMap.AutoMap();
            });
        }

       
    }
}
