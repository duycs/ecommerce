using Integration.Domain.AggregateModels.SystemLogAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ECommerce.Shared.SeedWork;
using ECommerce.Shared.Extensions;

namespace Integration.Infrastructure.EntityConfigurations.SystemLogAggregate
{
    public class SystemLogEntityConfiguration : EntityConfiguration<SystemLog>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SystemLog> builder)
        {
            builder.Ignore(a => a.LastUpdatedDate);

            var serializer = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
            };

            builder.Property(a => a.Contents)
                .HasColumnType("jsonb")
                .HasConversion(a => JsonConvert.SerializeObject(a, serializer),
                b => b.TryDeserialize<IList<ContentLog>>(serializer));
        }
    }
}