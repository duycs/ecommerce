using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Synchronize.Domain.OrderAggregate;
using System.Collections.Generic;

namespace Synchronize.Infrastructure.EntityConfigurations
{
    public class OrderDetailEntityConfiguration : EntityConfiguration<OrderDetail>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OrderDetail> builder)
        {
            var serializer = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
            };

            builder.Property(a => a.AttributeValues)
                .HasColumnType("jsonb")
                .HasConversion(a => JsonConvert.SerializeObject(a, serializer),
                b => b.TryDeserialize<IList<OrderProductAttributeValue>>(serializer));
        }
    }
}
