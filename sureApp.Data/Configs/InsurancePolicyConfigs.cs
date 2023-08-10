using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using sureApp.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sureApp.Data.Configs
{
    internal class InsurancePolicyConfigs
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<InsurancePolicy>(document =>
            {
                document.AutoMap();
                document.MapIdMember(x => x.Id)
                .SetIdGenerator(GuidGenerator.Instance)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
                document.MapMember(x => x.CustomerIdentifier).SetIsRequired(true);
            });

        }
    }
}
