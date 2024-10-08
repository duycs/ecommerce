using ECommerce.Shared.Dotnet.Repositories;
using Microsoft.EntityFrameworkCore;
using Notification.Domain.AggregateModels.NotificationAggregate;
using Notification.Domain.AggregateModels.TemplateAggregate;
using System;
using System.Reflection;

namespace Notification.Infrastructure
{
    public class NotificationDbContext : BaseDbContext
    {
        public static string SchemaName => "notification";

        public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public virtual DbSet<NotificationHistory> NotificationHistories { get; set; }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }

        public NotificationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(SchemaName);
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override string GetMigrationSchema()
        {
            return SchemaName;
        }
    }
}
