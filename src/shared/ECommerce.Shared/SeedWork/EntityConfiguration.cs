using ECommerce.Shared.Dotnet.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Shared.SeedWork
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            (builder as EntityTypeBuilder<IEntity>)?.HasKey((IEntity p) => p.Id);
            (builder as EntityTypeBuilder<IBaseAccount>)?.Ignore((IBaseAccount p) => p.FullName);
            ConfigureEntity(builder);
        }
    }
}
