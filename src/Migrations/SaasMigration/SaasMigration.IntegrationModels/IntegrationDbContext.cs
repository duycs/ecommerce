using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaasMigration.IntegrationModels.Models;

namespace SaasMigration.IntegrationModels
{
    public partial class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext()
        {
        }

        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttributeMapping> AttributeMappings { get; set; }
        public virtual DbSet<BrandMapping> BrandMappings { get; set; }
        public virtual DbSet<CategoryMapping> CategoryMappings { get; set; }
        public virtual DbSet<ChildProductMapping> ChildProductMappings { get; set; }
        public virtual DbSet<CustomerMapping> CustomerMappings { get; set; }
        public virtual DbSet<OrderMapping> OrderMappings { get; set; }
        public virtual DbSet<ProductMapping> ProductMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=Abcd@1234;Host=localhost;Port=5432;Database=ecommerce;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("integration");
            modelBuilder.Entity<AttributeMapping>(entity =>
            {
                entity.HasKey(e => e.AttributeValueId)
                    .HasName("pk_attribute_mappings");

                entity.ToTable("attribute_mappings", "integration");

                entity.Property(e => e.AttributeValueId)
                    .ValueGeneratedNever()
                    .HasColumnName("attribute_value_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            modelBuilder.Entity<BrandMapping>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("pk_brand_mappings");

                entity.ToTable("brand_mappings", "integration");

                entity.HasIndex(e => e.OldId, "ix_brand_mappings_old_id")
                    .IsUnique();

                entity.Property(e => e.BrandId)
                    .ValueGeneratedNever()
                    .HasColumnName("brand_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            modelBuilder.Entity<CategoryMapping>(entity =>
            {
                entity.HasKey(e => e.OldId)
                    .HasName("pk_category_mappings");

                entity.ToTable("category_mappings", "integration");

                entity.Property(e => e.OldId)
                    .ValueGeneratedNever()
                    .HasColumnName("old_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");
            });

            modelBuilder.Entity<ChildProductMapping>(entity =>
            {
                entity.HasKey(e => e.ChildProductId)
                    .HasName("pk_child_product_mappings");

                entity.ToTable("child_product_mappings", "integration");

                entity.HasIndex(e => e.OldId, "ix_child_product_mappings_old_id")
                    .IsUnique();

                entity.Property(e => e.ChildProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("child_product_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            modelBuilder.Entity<CustomerMapping>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("pk_customer_mappings");

                entity.ToTable("customer_mappings", "integration");

                entity.HasIndex(e => e.OldId, "ix_customer_mappings_old_id")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            modelBuilder.Entity<OrderMapping>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("pk_order_mappings");

                entity.ToTable("order_mappings", "integration");

                entity.HasIndex(e => e.OldId, "ix_order_mappings_old_id")
                    .IsUnique();

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            modelBuilder.Entity<ProductMapping>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("pk_product_mappings");

                entity.ToTable("product_mappings", "integration");

                entity.HasIndex(e => e.OldId, "ix_product_mappings_old_id")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.OldId).HasColumnName("old_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
