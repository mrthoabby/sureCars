using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using MongoDB.Bson.Serialization;
using sureApp.domain.CoverageFeatureEntity;
using sureApp.Infrastructure;

namespace Infrastructure.CoverageFeatureSource
{
    internal class CoverageFeatureConfig : ICommand
    {

        public async Task PreInitializator(ApplicationDbContext context,CreateAutoincrementalEntitys counter)
        {
            List<string> insuranceFeatures = new List<string>
            {
                "Cobertura de salud integral",
                "Protección en caso de robo o pérdida",
                "Seguro de accidentes personales",
                "Cobertura de daños a terceros",
                "Asistencia en viajes y emergencias",
                "Servicio de atención médica virtual",
                "Protección contra daños naturales",
                "Beneficios por invalidez",
                "Descuentos en servicios médicos y farmacias",
                "Protección legal y asesoramiento jurídico"
            };
            var repo = new CoverageFeatureRepository(context, counter);
            var entities = await repo.GetAllAsync();
            if (entities.Count() > 0)
            {
                return;
            }
            var tasks = insuranceFeatures.Select(incrementator =>
            {
                return Task.Run(async () =>

                {

                    var entity = new CoverageFeature
                    {
                        Name = incrementator,
                    };

                    await repo.CreateAsync(entity);
                });
            }).ToArray();
            await Task.WhenAll(tasks);
        }

        public void ToMap()
        {
            BsonClassMap.RegisterClassMap<CoverageFeature>(classMap =>
            {
                classMap.MapIdMember(x => x.Id);
                classMap.AutoMap();
            });
        }
    }
}
