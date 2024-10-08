using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasMigration.ECommerceModels
{
    public class EComIdentityDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public EComIdentityDbContext()
        {
        }

        public EComIdentityDbContext(DbContextOptions<EComIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("identity");
            base.OnModelCreating(builder);
            builder.Entity<Account>(entity =>
            {
                entity.ToTable("AspNetUsers");
            });
        }
    }
}
