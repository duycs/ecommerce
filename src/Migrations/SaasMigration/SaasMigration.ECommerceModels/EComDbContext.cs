using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaasMigration.ECommerceModels.Models;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class EComDbContext : DbContext
    {
        public EComDbContext()
        {
        }

        public EComDbContext(DbContextOptions<EComDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BestSellingProduct> BestSellingProducts { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<NewProduct> NewProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductChild> ProductChildren { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopBankAccount> ShopBankAccounts { get; set; }
        public virtual DbSet<SuggestProduct> SuggestProducts { get; set; }
        public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

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
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<BestSellingProduct>(entity =>
            {
                entity.ToTable("best_selling_products");

                entity.HasIndex(e => e.ProductId, "ix_best_selling_products_product_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.BestSellingProduct)
                    .HasForeignKey<BestSellingProduct>(d => d.ProductId)
                    .HasConstraintName("fk_best_selling_products_products_product_id");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.HasIndex(e => e.Code, "ix_brands_code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "ix_brands_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(160)
                    .HasColumnName("meta_description");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(160)
                    .HasColumnName("meta_keywords");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Slug).HasColumnName("slug");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");

                entity.HasIndex(e => e.CustomerId, "ix_carts_customer_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.CustomerId)
                    .HasConstraintName("fk_carts_customers_customer_id");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.ToTable("cart_details");

                entity.HasIndex(e => new { e.CartId, e.ProductChildId }, "ix_cart_details_cart_id_product_child_id")
                    .IsUnique();

                entity.HasIndex(e => e.ProductChildId, "ix_cart_details_product_child_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductChildId).HasColumnName("product_child_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("fk_cart_details_carts_cart_id");

                entity.HasOne(d => d.ProductChild)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductChildId)
                    .HasConstraintName("fk_cart_details_product_children_product_child_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.PhoneNumber, "ix_customers_phone_number")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Dob)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.ExtraPhoneNumbers).HasColumnName("extra_phone_numbers");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Liabilities).HasColumnName("liabilities");

                entity.Property(e => e.MaxLiabilities).HasColumnName("max_liabilities");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("customer_addresses");

                entity.HasIndex(e => e.CustomerId, "ix_customer_addresses_customer_id");

                entity.HasIndex(e => e.WardId, "ix_customer_addresses_ward_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.ReceiverName)
                    .IsRequired()
                    .HasColumnName("receiver_name")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.ReceiverPhoneNumber)
                    .IsRequired()
                    .HasColumnName("receiver_phone_number")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.WardId).HasColumnName("ward_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_customer_addresses_customers_customer_id");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_customer_addresses_wards_ward_id");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("districts");

                entity.HasIndex(e => e.ProvinceId, "ix_districts_province_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("fk_districts_provinces_province_id");
            });

            modelBuilder.Entity<NewProduct>(entity =>
            {
                entity.ToTable("new_products");

                entity.HasIndex(e => e.ProductId, "ix_new_products_product_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.NewProduct)
                    .HasForeignKey<NewProduct>(d => d.ProductId)
                    .HasConstraintName("fk_new_products_products_product_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.BrandId, "ix_products_brand_id");

                entity.HasIndex(e => e.CategoryId, "ix_products_category_id");

                entity.HasIndex(e => e.SearchVector, "ix_products_search_vector")
                    .HasMethod("gin");

                entity.HasIndex(e => e.ShopId, "ix_products_shop_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Images).HasColumnName("images");

                entity.Property(e => e.IsSellFullSize).HasColumnName("is_sell_full_size");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.MetaDescription).HasColumnName("meta_description");

                entity.Property(e => e.MetaKeywords).HasColumnName("meta_keywords");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SearchVector)
                    .HasColumnName("search_vector")
                    .HasComputedColumnSql("to_tsvector('english'::regconfig, ((name || ' '::text) || sku))", true);

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.SiteTitle).HasColumnName("site_title");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku");

                entity.Property(e => e.ThumbImage).HasColumnName("thumb_image");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_products_brands_brand_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_products_product_categories_category_id");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("fk_products_shops_shop_id");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("product_attributes");

                entity.HasIndex(e => e.ProductId, "ix_product_attributes_product_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product_attributes_products_product_id");
            });

            modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
                entity.ToTable("product_attribute_values");

                entity.HasIndex(e => e.AttributeId, "ix_product_attribute_values_attribute_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttributeId).HasColumnName("attribute_id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("fk_product_attribute_values_product_attributes_product_attribu");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_categories");

                entity.HasIndex(e => e.Code, "ix_product_categories_code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "ix_product_categories_name")
                    .IsUnique();

                entity.HasIndex(e => e.ParentId, "ix_product_categories_parent_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(160)
                    .HasColumnName("meta_description");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(160)
                    .HasColumnName("meta_keywords");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.SiteTitle)
                    .HasMaxLength(256)
                    .HasColumnName("site_title");

                entity.Property(e => e.Slug)
                    .HasMaxLength(256)
                    .HasColumnName("slug");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_product_categories_product_categories_parent_id");
            });

            modelBuilder.Entity<ProductChild>(entity =>
            {
                entity.ToTable("product_children");

                entity.HasIndex(e => e.ProductId, "ix_product_children_product_id");

                entity.HasIndex(e => e.Sku, "ix_product_children_sku")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttributeValueIds).HasColumnName("attribute_value_ids");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

                entity.Property(e => e.Sku).HasColumnName("sku");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductChildren)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product_children_products_product_id");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("product_prices");

                entity.HasIndex(e => e.ProductChildId, "ix_product_prices_product_child_id");

                entity.HasIndex(e => e.ProductId, "ix_product_prices_product_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.IsLimitQuantity).HasColumnName("is_limit_quantity");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PriceDiscount).HasColumnName("price_discount");

                entity.Property(e => e.ProductChildId).HasColumnName("product_child_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuantityFrom).HasColumnName("quantity_from");

                entity.Property(e => e.QuantityTo).HasColumnName("quantity_to");

                entity.HasOne(d => d.ProductChild)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.ProductChildId)
                    .HasConstraintName("fk_product_prices_product_children_product_child_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product_prices_products_product_id");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("provinces");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shops");

                entity.HasIndex(e => e.Code, "ix_shops_code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "ix_shops_name")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "ix_shops_phone_number")
                    .IsUnique();

                entity.HasIndex(e => e.WardId, "ix_shops_ward_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CoverImage).HasColumnName("cover_image");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.ImageList).HasColumnName("image_list");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.MetaDescription).HasColumnName("meta_description");

                entity.Property(e => e.MetaKeywords).HasColumnName("meta_keywords");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number");

                entity.Property(e => e.SiteTitle).HasColumnName("site_title");

                entity.Property(e => e.ThumbImage).HasColumnName("thumb_image");

                entity.Property(e => e.Video).HasColumnName("video");

                entity.Property(e => e.WardId).HasColumnName("ward_id");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("fk_shops_wards_ward_id");
            });

            modelBuilder.Entity<ShopBankAccount>(entity =>
            {
                entity.ToTable("shop_bank_accounts");

                entity.HasIndex(e => e.NumberAccount, "ix_shop_bank_accounts_number_account")
                    .IsUnique();

                entity.HasIndex(e => e.ShopId, "ix_shop_bank_accounts_shop_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountHolder).HasColumnName("account_holder");

                entity.Property(e => e.BranchName).HasColumnName("branch_name");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NumberAccount).HasColumnName("number_account");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopBankAccounts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("fk_shop_bank_accounts_shops_shop_id");
            });

            modelBuilder.Entity<SuggestProduct>(entity =>
            {
                entity.ToTable("suggest_products");

                entity.HasIndex(e => e.ProductId, "ix_suggest_products_product_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.SuggestProduct)
                    .HasForeignKey<SuggestProduct>(d => d.ProductId)
                    .HasConstraintName("fk_suggest_products_products_product_id");
            });

            modelBuilder.Entity<SystemConfiguration>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("pk_system_configurations");

                entity.ToTable("system_configurations");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("wards");

                entity.HasIndex(e => e.DistrictId, "ix_wards_district_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedById).HasColumnName("last_updated_by_id");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("fk_wards_districts_district_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
