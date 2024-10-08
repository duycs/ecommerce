using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using Integration.Domain.OrderAggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class OrderDetailEntityConfiguration : EntityConfiguration<OrderDetail>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_details", "order", t => t.ExcludeFromMigrations());
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
                b => b.TryDeserialize<IList<ProductAttributeValue>>(serializer));
        }
    }
}
