using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaasMigration.SaasModels.Models;

namespace SaasMigration.SaasModels
{
    public partial class SaasDbContext : DbContext
    {
        public SaasDbContext()
        {
        }

        public SaasDbContext(DbContextOptions<SaasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountingAccountEnter> AccountingAccountEnters { get; set; }
        public virtual DbSet<AccountingAccountTransactionHistory> AccountingAccountTransactionHistories { get; set; }
        public virtual DbSet<AccountingAccountTransfer> AccountingAccountTransfers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumMediaPivot> AlbumMediaPivots { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
        public virtual DbSet<AppsVersion> AppsVersions { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategoryPivot> ArticleCategoryPivots { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<AttributeTemplate> AttributeTemplates { get; set; }
        public virtual DbSet<AttributeTemplateDetail> AttributeTemplateDetails { get; set; }
        public virtual DbSet<AttributeTemplatePivot> AttributeTemplatePivots { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BuyCurrency> BuyCurrencies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ClearingDebt> ClearingDebts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerDebtChangeSlip> CustomerDebtChangeSlips { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<CustomerOrderApprove> CustomerOrderApproves { get; set; }
        public virtual DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public virtual DbSet<DanhMuc10> DanhMuc10s { get; set; }
        public virtual DbSet<DanhMuc5> DanhMuc5s { get; set; }
        public virtual DbSet<DebtTransfer> DebtTransfers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<GiavonspCsv> GiavonspCsvs { get; set; }
        public virtual DbSet<HrDepartment> HrDepartments { get; set; }
        public virtual DbSet<HrDepartmentDataRole> HrDepartmentDataRoles { get; set; }
        public virtual DbSet<HrStaff> HrStaffs { get; set; }
        public virtual DbSet<ImportProductError> ImportProductErrors { get; set; }
        public virtual DbSet<ImportProductErrorDetail> ImportProductErrorDetails { get; set; }
        public virtual DbSet<ImportVendor> ImportVendors { get; set; }
        public virtual DbSet<ImportVendorDetail> ImportVendorDetails { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<IntProductPrice> IntProductPrices { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryDepartment> InventoryDepartments { get; set; }
        public virtual DbSet<InventoryDepartmentDeficient> InventoryDepartmentDeficients { get; set; }
        public virtual DbSet<InventoryDepartmentDetail> InventoryDepartmentDetails { get; set; }
        public virtual DbSet<InventoryDetail> InventoryDetails { get; set; }
        public virtual DbSet<InventorySlip> InventorySlips { get; set; }
        public virtual DbSet<InventorySlipDetail> InventorySlipDetails { get; set; }
        public virtual DbSet<Ledger> Ledgers { get; set; }
        public virtual DbSet<LedgerCategory> LedgerCategories { get; set; }
        public virtual DbSet<LiabilitiesAccount> LiabilitiesAccounts { get; set; }
        public virtual DbSet<LiabilitiesCategory> LiabilitiesCategories { get; set; }
        public virtual DbSet<LiabilitiesTimeline> LiabilitiesTimelines { get; set; }
        public virtual DbSet<LiabilitiesTimelineVendorOrder> LiabilitiesTimelineVendorOrders { get; set; }
        public virtual DbSet<MediaThumbnail> MediaThumbnails { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<MetaDatum> MetaData { get; set; }
        public virtual DbSet<MoneyAccount> MoneyAccounts { get; set; }
        public virtual DbSet<MoneyToForeignCurrencyAccount> MoneyToForeignCurrencyAccounts { get; set; }
        public virtual DbSet<PrintQueue> PrintQueues { get; set; }
        public virtual DbSet<Printer> Printers { get; set; }
        public virtual DbSet<PrinterService> PrinterServices { get; set; }
        public virtual DbSet<PrinterServicePivot> PrinterServicePivots { get; set; }
        public virtual DbSet<PrinterTargetPivot> PrinterTargetPivots { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeGroup> ProductAttributeGroups { get; set; }
        public virtual DbSet<ProductAttributeGroupPivot> ProductAttributeGroupPivots { get; set; }
        public virtual DbSet<ProductAttributePivot> ProductAttributePivots { get; set; }
        public virtual DbSet<ProductAttributeType> ProductAttributeTypes { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCategoryPivot> ProductCategoryPivots { get; set; }
        public virtual DbSet<ProductMediaPivot> ProductMediaPivots { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductPriceBill> ProductPriceBills { get; set; }
        public virtual DbSet<ProductPriceBillDetail> ProductPriceBillDetails { get; set; }
        public virtual DbSet<ProductUpdateCost> ProductUpdateCosts { get; set; }
        public virtual DbSet<ProductVendorStore> ProductVendorStores { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<ReportCustomerOrder> ReportCustomerOrders { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<StatisticAccountingDay> StatisticAccountingDays { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusGroup> StatusGroups { get; set; }
        public virtual DbSet<StatusGroupPivot> StatusGroupPivots { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreArea> StoreAreas { get; set; }
        public virtual DbSet<StoreOrder> StoreOrders { get; set; }
        public virtual DbSet<StoreOrderDetail> StoreOrderDetails { get; set; }
        public virtual DbSet<SystemDataRole> SystemDataRoles { get; set; }
        public virtual DbSet<SystemDataRoleFullPermission> SystemDataRoleFullPermissions { get; set; }
        public virtual DbSet<SystemModule> SystemModules { get; set; }
        public virtual DbSet<SystemRole> SystemRoles { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemUserGroupPivot> SystemUserGroupPivots { get; set; }
        public virtual DbSet<SystemUserMoneyAccountPivot> SystemUserMoneyAccountPivots { get; set; }
        public virtual DbSet<SystemUserRolePivot> SystemUserRolePivots { get; set; }
        public virtual DbSet<Taxonomy> Taxonomies { get; set; }
        public virtual DbSet<TaxonomyTerm> TaxonomyTerms { get; set; }
        public virtual DbSet<TemplateTable> TemplateTables { get; set; }
        public virtual DbSet<ThanhToanNcc> ThanhToanNccs { get; set; }
        public virtual DbSet<Transporter> Transporters { get; set; }
        public virtual DbSet<TransporterPrice> TransporterPrices { get; set; }
        public virtual DbSet<TransporterPriceBill> TransporterPriceBills { get; set; }
        public virtual DbSet<TransporterPriceBillDetail> TransporterPriceBillDetails { get; set; }
        public virtual DbSet<TransporterVendorOrderBill> TransporterVendorOrderBills { get; set; }
        public virtual DbSet<TransporterVendorOrderBillDetail> TransporterVendorOrderBillDetails { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorOrder> VendorOrders { get; set; }
        public virtual DbSet<VendorOrderDetail> VendorOrderDetails { get; set; }
        public virtual DbSet<VendorOrderDetailV2> VendorOrderDetailV2s { get; set; }
        public virtual DbSet<VendorOrderReturn> VendorOrderReturns { get; set; }
        public virtual DbSet<VendorOrderReturnDetail> VendorOrderReturnDetails { get; set; }
        public virtual DbSet<VendorOrderV2> VendorOrderV2s { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.2.2;port=3307;user=root;password=Abcd@1234;database=saas;charset=utf8;treattinyasboolean=true;convert zero datetime=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AccountingAccountEnter>(entity =>
            {
                entity.ToTable("_accounting_account_enter");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AccountId).HasComment("ID tài khoản nhập quỹ hoặc rút quỹ.");

                entity.Property(e => e.BillCode)
                    .HasMaxLength(64)
                    .HasComment("Mã phiếu.");

                entity.Property(e => e.BillDate).HasComment("Ngày lập phiếu.");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasComment("Diễn giải.");

                entity.Property(e => e.EnterType)
                    .HasColumnType("enum('enter','exit')")
                    .HasComment("Hành động: Nhập quỹ hoặc Rút quỹ.");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SourceId).HasComment("Id nguồn");

                entity.Property(e => e.SourceType)
                    .HasColumnType("enum('buy_currency')")
                    .HasComment("Nguồn tạo phiếu nhập quỹ( nếu có)");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền.");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<AccountingAccountTransactionHistory>(entity =>
            {
                entity.ToTable("_accounting_account_transaction_history");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.TransactionType, e.AccountId, e.TransactionId }, "_accounting_account_transaction_history_TransactionType_IDX");

                entity.Property(e => e.AccountId).HasComment("ID tài khoản kế toán");

                entity.Property(e => e.ChangeType)
                    .HasColumnType("enum('increase','decrease')")
                    .HasComment("Biến động tăng thay giảm");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreditBalance)
                    .HasPrecision(23, 2)
                    .HasComment("Số dư có");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OldCreditBalance)
                    .HasPrecision(23, 2)
                    .HasComment("Số dư có");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền giao dịch");

                entity.Property(e => e.TransactionDate).HasComment("Ngày giao dịch");

                entity.Property(e => e.TransactionId).HasComment("Id giao dịch: Id phiếu Thu/Chi, Id phiếu chuyển tiền giữa các tài khoản, Id phiếu nhập quỹ.");

                entity.Property(e => e.TransactionType)
                    .HasColumnType("enum('ledger_in','ledger_out','account_transfer','account_enter','account_exit')")
                    .HasComment("Loại giao dịch: phiếu Thu/Chi, chuyển tiền giữa các tài khoản.");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<AccountingAccountTransfer>(entity =>
            {
                entity.ToTable("_accounting_account_transfer");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(600)
                    .HasComment("Ghi chú");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.SourceAccountId).HasComment("ID tài khoản kế toán (MoneyAccountId) chuyển tiền");

                entity.Property(e => e.TargetAccountId).HasComment("Tài khoản kế toán nhận tiền");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền chuyển");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("_album");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsPublished).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasMaxLength(125);

                entity.Property(e => e.Slug).HasMaxLength(150);
            });

            modelBuilder.Entity<AlbumMediaPivot>(entity =>
            {
                entity.ToTable("_album_media_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.ToTable("_app_config");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasComment("Mô tả");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsSystemConfig).HasDefaultValueSql("'1'");

                entity.Property(e => e.Key)
                    .HasMaxLength(100)
                    .HasComment("Config key");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Priority).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Value)
                    .HasMaxLength(600)
                    .HasComment("Config value");

                entity.Property(e => e.Version)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Version");
            });

            modelBuilder.Entity<AppsVersion>(entity =>
            {
                entity.ToTable("_apps_version");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AppKey)
                    .HasMaxLength(100)
                    .HasComment("Key định danh của ứng dụng, ví dụ: pexnic_staff");

                entity.Property(e => e.AppName)
                    .HasMaxLength(300)
                    .HasComment("Tên ứng dụng. Ví dụ: App quản lý bán hàng.");

                entity.Property(e => e.AppType)
                    .HasColumnType("enum('android','iOS','webapp')")
                    .HasComment("Kiểu ứng dụng: Android, iOS, WebApp");

                entity.Property(e => e.AppVersion)
                    .HasMaxLength(100)
                    .HasComment("Version của ứng dụng");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasColumnType("mediumtext")
                    .HasComment("Mô tả cho phiên bản ứng dụng");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Priority).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Phiên bản của bản ghi");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("_article");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Detail).HasColumnType("text");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsPublished).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ArticleCategoryPivot>(entity =>
            {
                entity.ToTable("_article_category_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("_attachment");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DownloadToken).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.FileType).HasMaxLength(10);

                entity.Property(e => e.FileUrl).HasMaxLength(255);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<AttributeTemplate>(entity =>
            {
                entity.ToTable("_attribute_template");

                entity.HasComment("Bảng cấu hình nhóm thuộc tính. Vd: Giày gồm Size, Màu sắc")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FixedTypeId).HasComment("Thuoc tinh co dinh");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDefaulted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<AttributeTemplateDetail>(entity =>
            {
                entity.ToTable("_attribute_template_detail");

                entity.HasComment("Bảng lưu dữ liệu thuộc tính của sản phẩm cha")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InputType)
                    .HasColumnType("enum('show','input','inputFixed')")
                    .HasDefaultValueSql("'input'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<AttributeTemplatePivot>(entity =>
            {
                entity.ToTable("_attribute_template_pivot");

                entity.HasComment("Bảng lưu dữ liệu thuộc tính của sản phẩm cha")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InputType)
                    .HasColumnType("enum('show','input','inputFixed')")
                    .HasDefaultValueSql("'input'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.TemplateId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("_brand");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .HasComment("Ma thuong hieu");

                entity.Property(e => e.CountryCode).HasMaxLength(16);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.District).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.Fax).HasMaxLength(16);

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(16);

                entity.Property(e => e.Province).HasMaxLength(128);

                entity.Property(e => e.Slug).HasMaxLength(256);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Website).HasMaxLength(128);
            });

            modelBuilder.Entity<BuyCurrency>(entity =>
            {
                entity.ToTable("_buy_currency");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode)
                    .HasMaxLength(64)
                    .HasComment("Mã phiếu mua ngoại tệ.");

                entity.Property(e => e.BillDate).HasComment("Ngày mua ngoại tệ.");

                entity.Property(e => e.BuyAccountId).HasComment("ID tài khoản mua ngoại tệ.");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasComment("Mã ngoại tệ.");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasComment("Diễn giải.");

                entity.Property(e => e.EnterAccountId).HasComment("ID tài khoản ngoại tệ, là tài khoản được nhập số ngoại tệ mua vào.");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasComment("Tỷ giá.");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền bỏ ra mua ngoại tệ.");

                entity.Property(e => e.TotalCurrency)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số ngoại tệ mua được.");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("_category");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => e.Slug, "Slug_Index");

                entity.HasIndex(e => new { e.Slug, e.Type }, "Slug_Type_Unique")
                    .IsUnique();

                entity.HasIndex(e => e.Type, "Type_Index");

                entity.Property(e => e.Config).HasColumnType("text");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ClearingDebt>(entity =>
            {
                entity.ToTable("_clearing_debt");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreditBalanceAfterPayment)
                    .HasPrecision(23, 2)
                    .HasComment("Số dự nợ SAU khi thanh toán của tài khoản thanh toán");

                entity.Property(e => e.CreditBalanceBeforePayment)
                    .HasPrecision(23, 2)
                    .HasComment("Số dự nợ TRƯỚC khi thanh toán của tài khoản thanh toán");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(20)
                    .HasComment("Tiền tệ.  Mã tiền tệ");

                entity.Property(e => e.DateBill)
                    .HasColumnType("datetime")
                    .HasComment("ngày tạo bill");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasComment("Mô tả (diễn giải)");

                entity.Property(e => e.DetailPaymentAmout)
                    .HasColumnType("json")
                    .HasComment("Chi tiết thanh toán tiền từ các nguồn vào tài khoản thanh toán");

                entity.Property(e => e.DetailPaymentBill)
                    .HasColumnType("json")
                    .HasComment("Chi tiết thanh toán cho các Đơn hàng ( đặt, nhập....)");

                entity.Property(e => e.DiffirenceAmount)
                    .HasPrecision(23, 2)
                    .HasComment("DiffirenceAmount = TotalAmountPayment - TotalAmountExpectedPayment ( tổng tiền chênh khi thanh toán)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.LiabilitiesAfter)
                    .HasPrecision(23, 2)
                    .HasComment("Công nợ TargetId sau khi thanh toán");

                entity.Property(e => e.LiabilitiesBefore)
                    .HasPrecision(23, 2)
                    .HasComment("Công nợ TargetId trước khi thanh toán");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.MoneyAccountId).HasComment("Tài khoản kế toán");

                entity.Property(e => e.PaymentAmount)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền thanh toán");

                entity.Property(e => e.RecordOrder).HasMaxLength(11);

                entity.Property(e => e.TargetId).HasComment("ID của đối tượng cần truy vấn (VendorId: 1)");

                entity.Property(e => e.TargetType)
                    .HasColumnType("enum('vendor')")
                    .HasComment("Đối tượng: enum('vendor')");

                entity.Property(e => e.TotalAmountExpectedPayment)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền thanh toán dự kiến theo quốc gia theo TargetCurrenyCode( Ví dụ: Việt Nam là VND)");

                entity.Property(e => e.TotalAmountPayment)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền thanh toán theo quốc gia theo TargetCurrenyCode( Ví dụ: Việt Nam là VND)");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("_contact");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Feedback).HasColumnType("text");

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Uid).HasMaxLength(32);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("_country");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CountryCode).HasMaxLength(32);

                entity.Property(e => e.CountryName).HasMaxLength(32);

                entity.Property(e => e.CountryVn)
                    .HasMaxLength(128)
                    .HasColumnName("CountryVN");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FlagIcon).HasMaxLength(300);

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsoCodeAlpha2).HasMaxLength(32);

                entity.Property(e => e.IsoCodeAlpha3).HasMaxLength(32);

                entity.Property(e => e.IsoCodes).HasMaxLength(32);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("_currency");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CountryName).HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode).HasMaxLength(64);

                entity.Property(e => e.CurrencyName).HasMaxLength(64);

                entity.Property(e => e.CurrencyNumber).HasMaxLength(64);

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsoCodeAlpha2).HasMaxLength(32);

                entity.Property(e => e.IsoCodeAlpha3).HasMaxLength(32);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("_customer");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => e.FullName, "_customer_FullName_IDX")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.Property(e => e.ActiveTime).HasColumnType("datetime");

                entity.Property(e => e.ActiveTimeExpired).HasColumnType("datetime");

                entity.Property(e => e.ActiveToken).HasMaxLength(64);

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Avatar).HasMaxLength(125);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustomerOrderNumber)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Số thứ tự đơn hàng dành riêng cho từng khách hàng.");

                entity.Property(e => e.CustomerType)
                    .HasColumnType("enum('wholesale','retail')")
                    .HasComment("Kiểu (nhóm) khách hàng: Khách bán buôn, bán lẻ,...");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasColumnType("enum('other','female','male')");

                entity.Property(e => e.IndentityCard).HasMaxLength(25);

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Cong no hien tai");

                entity.Property(e => e.MaxLiabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gioi han cong no cho phep");

                entity.Property(e => e.MembershipClass).HasColumnType("enum('vip','diamon','platinum','gold','silver','nomal')");

                entity.Property(e => e.MetaData).HasMaxLength(255);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.Phone1).HasMaxLength(25);

                entity.Property(e => e.Phone2).HasMaxLength(25);

                entity.Property(e => e.Phone3).HasMaxLength(25);

                entity.Property(e => e.Phone4).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.RecoverPasswordToken).HasMaxLength(64);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<CustomerDebtChangeSlip>(entity =>
            {
                entity.ToTable("_customer_debt_change_slip");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustomerId).HasComment("Id khách hàng");

                entity.Property(e => e.DebtChangeCode).HasMaxLength(16);

                entity.Property(e => e.DebtMaxNew)
                    .HasPrecision(23, 2)
                    .HasComment("gioi han cong no moi");

                entity.Property(e => e.DebtMaxOld)
                    .HasPrecision(23, 2)
                    .HasComment("gioi han cong no cu");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Notes).HasMaxLength(600);

                entity.Property(e => e.RecordOrder).HasMaxLength(15);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("_customer_order");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.CustomerId, e.StoreId }, "_customer_order_CustomerId_IDX");

                entity.Property(e => e.AccountingAccountId).HasComment("ID tài khoản kế toán");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustomerGetBack)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("So tien thua khach nhan ve");

                entity.Property(e => e.CustomerGive)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("So tien khach dua");

                entity.Property(e => e.CustomerPay)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("CustomerPay = CustomerGive - CustomerGetBack");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.GrandTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tien sau khi tinh toan thue, van chuyen, ...");

                entity.Property(e => e.GrossRevenue)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng doanh thu đơn hàng");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDebtNotifyCustomer).HasComment("Trạng thái xác định đã thông báo cho khách trong trường hợp đơn hàng vượt định mức công nợ.");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsLiabilitiesExceed).HasColumnType("bit(1)");

                entity.Property(e => e.IsLiabilitiesExceedRequest).HasColumnType("bit(1)");

                entity.Property(e => e.IsShippingNow).HasComment("Trạng thái đơn hàng cần [Giao ngay], phục vụ cho bộ phận kho nhặt hàng và chuyển hàng luôn.");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.NoteInternal).HasMaxLength(600);

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.OrderTransactionType)
                    .HasColumnType("enum('change_type','return_type','order_type','primary_type')")
                    .HasDefaultValueSql("'primary_type'")
                    .HasComment("Chinh thuc, tra hang, doi hang");

                entity.Property(e => e.OrderType).HasColumnType("enum('wholesale','retail')");

                entity.Property(e => e.PaymentTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian thanh toán");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.RequestPaymentTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian yêu cầu thanh toán");

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tam tinh thanh tien tren cac items");

                entity.Property(e => e.Tax)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tien thue");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tong tien sau khi tru di discount");

                entity.Property(e => e.TotalCost)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng giá vốn bán hàng");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CustomerOrderApprove>(entity =>
            {
                entity.ToTable("_customer_order_approve");

                entity.HasComment("Danh sach don hang vuot qua dinh muc cong no can phe duyet")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AllowedLiabilities).HasPrecision(23, 2);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustomerId).HasDefaultValueSql("'0'");

                entity.Property(e => e.ExpectedLiabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Muc cong no du kien");

                entity.Property(e => e.Expenses)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Chi phi don hang: GrandTotal");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsResponded)
                    .HasColumnType("bit(1)")
                    .HasComment("Xac nhan da co phan hoi tu quan ly hay chua");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Cong no hien tai");

                entity.Property(e => e.ManagerId).HasComment("Quan ly");

                entity.Property(e => e.MaxLiabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Dinh muc cong no hien tai");

                entity.Property(e => e.MaxLiabilitiesExtra)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Cho phep cong them mot muc tang cong no toi da. Vi du: dmcn hien la 50.000.000, cho phep thep 20.000.000");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.TotalPay)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tien khach tra");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<CustomerOrderDetail>(entity =>
            {
                entity.ToTable("_customer_order_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.CustomerOrderId, e.ParentProductId, e.ProductModelId }, "_customer_order_detail_CustomerOrderId_IDX");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban");

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá bán lẻ");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá bán buôn");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.Sku).HasMaxLength(64);

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalCost)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng giá vốn bán hàng");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<DanhMuc10>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("danh_muc_10");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DanhMuc).HasMaxLength(20);

                entity.Property(e => e.MaDanhMuc).HasMaxLength(5);
            });

            modelBuilder.Entity<DanhMuc5>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("danh_muc_5");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DanhMuc).HasMaxLength(31);

                entity.Property(e => e.MaDanhMuc).HasMaxLength(6);
            });

            modelBuilder.Entity<DebtTransfer>(entity =>
            {
                entity.ToTable("_debt_transfer");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(16);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DestinationObjectType).HasColumnType("enum('customer','vendor','transporter')");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(600)
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.SourceObjectType).HasColumnType("enum('customer','vendor','transporter')");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("_district");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(25);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasMaxLength(125)
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.ToTable("_exchange_rate");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Displayable).HasDefaultValueSql("'1'");

                entity.Property(e => e.Exchange)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SourceCurrencyCode).HasMaxLength(32);

                entity.Property(e => e.TargetCurrencyCode).HasMaxLength(32);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("_feed_back");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.App)
                    .HasColumnType("enum('ios','android','web')")
                    .HasComment("Ứng dụng");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasComment("Nội dung feedback");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UserFeedBackId).HasComment("Người feedback");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasComment("Version bản ghi");
            });

            modelBuilder.Entity<GiavonspCsv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("giavonsp_csv");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CostAvg)
                    .HasPrecision(10)
                    .HasColumnName("CostAVG");
            });

            modelBuilder.Entity<HrDepartment>(entity =>
            {
                entity.ToTable("_hr_department");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.IsActivated)
                    .HasDefaultValueSql("'0'")
                    .HasComment("TrÃƒÂ¡Ã‚ÂºÃ‚Â¡ng thÃƒÆ’Ã‚Â¡i hoÃƒÂ¡Ã‚ÂºÃ‚Â¡t Ãƒâ€žÃ¢â‚¬ËœÃƒÂ¡Ã‚Â»Ã¢â€žÂ¢ng");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("'uuid()'");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<HrDepartmentDataRole>(entity =>
            {
                entity.ToTable("_hr_department_data_role");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.DataId, e.DepartmentId }, "_hr_department_data_role_DataId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DataType).HasMaxLength(64);

                entity.Property(e => e.Directly).HasComment("Vi tri du lieu duoc gan truc tiep, tranh nham lan voi cap cha hoac con");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StatusCode).HasMaxLength(32);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<HrStaff>(entity =>
            {
                entity.ToTable("_hr_staff");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AccountId)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Account ID");

                entity.Property(e => e.ActiveTime).HasColumnType("datetime");

                entity.Property(e => e.ActiveTimeExpired).HasColumnType("datetime");

                entity.Property(e => e.ActiveToken)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DepartmentId).HasComment("ID bộ phận");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Gender).HasColumnType("enum('male','female','other')");

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdentityCard)
                    .HasMaxLength(25)
                    .HasComment("Số CMND")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IsActivated)
                    .HasDefaultValueSql("'0'")
                    .HasComment("TrÃƒÂ¡Ã‚ÂºÃ‚Â¡ng thÃƒÆ’Ã‚Â¡i hoÃƒÂ¡Ã‚ÂºÃ‚Â¡t Ãƒâ€žÃ¢â‚¬ËœÃƒÂ¡Ã‚Â»Ã¢â€žÂ¢ng");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LoginStatus).HasColumnType("enum('loggedin','loggedin_facebook','loggedin_google','loggedin_zalo','loggedout')");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RecoverPasswordToken)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RememberToken).HasMaxLength(255);

                entity.Property(e => e.RememberWhen).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasComment("ID Kho/Cá»­a hÃ ng");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ZaloId)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ImportProductError>(entity =>
            {
                entity.ToTable("_import_product_error");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateTimeImport)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian chuyển");

                entity.Property(e => e.ImportProductErrorCode).HasMaxLength(32);

                entity.Property(e => e.ImportProductErrorRecord).HasMaxLength(7);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(600)
                    .HasComment("Ghi chú đơn nhập hàng lỗi");

                entity.Property(e => e.StoreId).HasComment("Kho nhập");

                entity.Property(e => e.TotalCost)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng tiền Cost");

                entity.Property(e => e.TotalPriceRetail)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng tiền bán lẻ");

                entity.Property(e => e.TotalPriceWholesale)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng tiền bán buôn");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số lượng trong phiếu");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ImportProductErrorDetail>(entity =>
            {
                entity.ToTable("_import_product_error_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasComment("Giá vốn bình quân");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateTimeImport)
                    .HasColumnType("datetime")
                    .HasComment("thời gian chuyển");

                entity.Property(e => e.ImportProductErrorCode)
                    .HasMaxLength(32)
                    .HasComment("Mã phiếu cha");

                entity.Property(e => e.ImportProductErrorId).HasComment("Id phiếu nhập");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParentProductId).HasComment("Id sản phẩm cha");

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasComment("Giá bán lẻ");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasComment("Giá bán buôn");

                entity.Property(e => e.ProductId).HasComment("Id sản phẩm");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasComment("Số lượng nhập lỗi");

                entity.Property(e => e.Sku)
                    .HasMaxLength(64)
                    .HasComment("Sku của sản phẩm");

                entity.Property(e => e.StoreId).HasComment("Kho nhập");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ImportVendor>(entity =>
            {
                entity.ToTable("_import_vendor");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatorId).HasComment("Người tạo");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(20)
                    .HasComment("CurrencyCode của đơn đặt");

                entity.Property(e => e.DateImported)
                    .HasColumnType("datetime")
                    .HasComment("Ngày giờ  nhập");

                entity.Property(e => e.EditorId).HasComment("Người sửa");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(11, 2)
                    .HasComment("giá đón quy đổi ra VND");

                entity.Property(e => e.IsDeleted).HasComment("không xoá: 0, Xoá: 1");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú");

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(64)
                    .HasComment("Mã đơn nhập");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(64)
                    .HasComment("số thứ tự đơn");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(60)
                    .HasComment("\"- Trạng thái đơn hàng.\n- Trạng thái: \n1. importing : đang nhập\n2. completed : hoàn thành\"");

                entity.Property(e => e.StoreId).HasComment("Id cửa hàng");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng nhập của đơn");

                entity.Property(e => e.TransporterId).HasComment("Id nhà vận chuyển");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.VendorId).HasComment("Id nhà cung cấp");

                entity.Property(e => e.VendorOrderId).HasComment("Id đơn đặt hàng. Reference   bảng _vendor_order_v2");

                entity.Property(e => e.Version).HasComment("Version bản ghi");
            });

            modelBuilder.Entity<ImportVendorDetail>(entity =>
            {
                entity.ToTable("_import_vendor_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CategoryId).HasComment("CategoryId của bảng sản phẩm");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatorId).HasComment("Người tạo");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(16)
                    .HasComment("Tiền tệ.  Mã tiền tệ theo quốc gia");

                entity.Property(e => e.EditorId).HasComment("Người sửa");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(11, 2)
                    .HasComment("giá đón quy đổi ra VND");

                entity.Property(e => e.ImportVendorId).HasComment("Id nhập hàng từ nhà cung cấp. Reference bảng _import_product_vendor");

                entity.Property(e => e.IsDeleted).HasComment("không xoá: 0, Xoá: 1");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParentProductId).HasComment("Id sản phẩm cha");

                entity.Property(e => e.Priority).HasComment("Thứ tự sắp xếp của AttributeFixed của Peoduct khi nhập hàng. ( để hiển thị đúng thứ tự nhập của người dùng theo AttributeFixedId)");

                entity.Property(e => e.ProductId).HasComment("Id sản phẩm");

                entity.Property(e => e.Quantity)
                    .HasPrecision(11, 2)
                    .HasComment("Số lượng Nhập");

                entity.Property(e => e.Sku)
                    .HasMaxLength(64)
                    .HasComment("Mã Sku của ProductId");

                entity.Property(e => e.SkuFromVendor)
                    .HasMaxLength(64)
                    .HasComment("Mã đặt hàng từ nhà cung cấp");

                entity.Property(e => e.StoreId).HasComment("Id cửa hàng");

                entity.Property(e => e.TransporterId).HasComment("Id nhà vận chuyển");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.VendorId).HasComment("Id nhà cung cấp");

                entity.Property(e => e.VendorOrderId).HasComment("Id đơn đặt hàng. Reference   bảng _vendor_order_v2");

                entity.Property(e => e.Version).HasComment("Version bản ghi");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("_industry");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(150);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasMaxLength(125);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<IntProductPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_int_product_price");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PriceRetail).HasColumnType("double(23,4)");

                entity.Property(e => e.PriceWholesale).HasColumnType("double(23,4)");

                entity.Property(e => e.Sku).HasMaxLength(64);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("_inventory");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.TransporterId, e.ImportVendorId, e.ExportVendorId, e.ImportStoreId, e.ExportStoreId, e.RelatedBillId }, "_inventory_TransporterId_IDX");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillGroup)
                    .HasMaxLength(32)
                    .HasComment("Source groups. Ex: vendor, store. Import/export from vendor, store, ...");

                entity.Property(e => e.BillType).HasColumnType("enum('export','import')");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ImportStoreId).HasDefaultValueSql("'0'");

                entity.Property(e => e.ImportVendorId).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.RelatedBillId).HasComment("Source bill Id. ex: VendorOrderId, StoreOrderId,...");

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TransporterId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<InventoryDepartment>(entity =>
            {
                entity.ToTable("_inventory_department");

                entity.HasComment("Phieu xuat hang cho moi bo phan kho")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.OrderId, e.StoreId, e.DepartmentId, e.CustomerId, e.VendorId, e.TransporterId, e.StaffId }, "_inventory_department_OrderId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeficient)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("Trang thai thieu hang");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderActionType).HasColumnType("enum('export','import')");

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.OrderType).HasColumnType("enum('other_order','store_order','customer_order','vendor_order')");

                entity.Property(e => e.RecordOrderItem).HasComment("So thu tu phieu. Vi du : so thu tu la 3, tren tong so 5 phieu, hien thi ra man hinh la 3/5");

                entity.Property(e => e.RecordOrderTotal).HasComment("Tong so phieu xuat, chinh bang tong so bo phan tham gia. Vi du :  tong so phieu xuat la 5.");

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalQuantityOrder)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<InventoryDepartmentDeficient>(entity =>
            {
                entity.ToTable("_inventory_department_deficient");

                entity.HasComment("Ghi chu truong hop hang thieu so voi don hang")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DepartmentBillId).HasComment("Phieu xuat hang tu bo phan kho. ID tu bang CustomerOrderStoreDepartment");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.OrderType).HasColumnType("enum('other_order','store_order','customer_order','vendor_order')");

                entity.Property(e => e.ProductModelId).HasDefaultValueSql("'0'");

                entity.Property(e => e.ProductVendorId).HasDefaultValueSql("'0'");

                entity.Property(e => e.QuantityExport)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantityOrder)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<InventoryDepartmentDetail>(entity =>
            {
                entity.ToTable("_inventory_department_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.ParentProductId, e.InventoryDepartmentId, e.ProductModelId }, "_inventory_department_detail_ParentProductId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InventoryDepartmentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ProductVendorId)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Product ID from _product_vendor_pivot");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.QuantityOrder)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<InventoryDetail>(entity =>
            {
                entity.ToTable("_inventory_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.ParentProductId, e.ProductModelId, e.InventoryId }, "_inventory_detail_ParentProductId_IDX");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExtraQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("số lượng nhập bổ sung");

                entity.Property(e => e.InitQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số lượng khi xác nhận nhập kho");

                entity.Property(e => e.InventoryId).HasComment("ID from _vendor_order");

                entity.Property(e => e.IsExtraImport).HasComment("Trang thai san pham nhap khong nam trong danh sach dat hang NCC");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban");

                entity.Property(e => e.ProductVendorId)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Product ID from _product_vendor_pivot");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.SkuVendor).HasMaxLength(64);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version)
                    .HasDefaultValueSql("'1'")
                    .HasComment("Phiên bản của bản ghi");
            });

            modelBuilder.Entity<InventorySlip>(entity =>
            {
                entity.ToTable("_inventory_slip");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Date).HasComment("Ngày kiểm kho");

                entity.Property(e => e.InventorySlipCode)
                    .HasMaxLength(64)
                    .HasComment("Mã phiếu kiểm kho");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RecordOrder).HasMaxLength(7);

                entity.Property(e => e.StoreId).HasComment("Id cửa hàng");

                entity.Property(e => e.TotalCostDifference)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tổng tiền chênh của kiểm kho so với tồn theo Cost");

                entity.Property(e => e.TotalPriceDifference)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng tiền chênh lệch cua kiểm kho va ton kho theo gia bán buôn. Tinh theo tổng từ dưới lên");

                entity.Property(e => e.TotalPriceRetailDifference)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tổng tiền chênh theo gia bán lẻ");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(11, 2)
                    .HasComment("Tong so luong san pham cua phieu kiem kho");

                entity.Property(e => e.TotalQuantityDefference)
                    .HasPrecision(11, 2)
                    .HasComment("Tong so luong chenh lech gia kiem kho va ton kho truoc khi kiem. TotalQuantity - TotalQuantityVendor");

                entity.Property(e => e.TotalQuantityVendor)
                    .HasPrecision(11, 2)
                    .HasComment("Tong So luong ton kho truoc khi ghi nhan kiem kho");

                entity.Property(e => e.TotalQuantityVendorStore)
                    .HasPrecision(11, 2)
                    .HasComment("Tong So luong ton kho truoc khi ghi nhan kiem kho");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<InventorySlipDetail>(entity =>
            {
                entity.ToTable("_inventory_slip_detail");

                entity.HasComment("Bảng chi tiết phiếu kiểm kho")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CostProduct)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá vốn sản phẩm khi keiẻm kho");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Date).HasComment("Ngày kiểm kho và bằng với Ngày kiểm kho của bàng [_inventory_slip]");

                entity.Property(e => e.DepartmentId).HasComment("Id bo phan");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.NumberUpdate)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Tổng số lần cập nhật");

                entity.Property(e => e.ParentProductId).HasComment("Id sản phẩm cha");

                entity.Property(e => e.PriceProduct)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia bán buôn san pham tai thoi diem kiem kho");

                entity.Property(e => e.PriceRetailProduct)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("giá bán lẻ sản phẩm khi kiểm kho");

                entity.Property(e => e.ProductId).HasComment("Id sản phẩm");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantityVendorStore)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Sku)
                    .HasMaxLength(64)
                    .HasComment("Mã Sku của hệ thống");

                entity.Property(e => e.SkuFromVendor).HasMaxLength(64);

                entity.Property(e => e.StoreId).HasComment("Id cửa hàng");

                entity.Property(e => e.TotalCostDifference)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("tổng chênh theo Cost");

                entity.Property(e => e.TotalPriceDifference)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tong tien chenh lech gia kiem kho va ton kho. CT = (Quantity - QuantityVendorStore) * PriceProduct");

                entity.Property(e => e.TotalPriceRetailDifference)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tổng tiền chênh theo giá bán lẻ");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Ledger>(entity =>
            {
                entity.ToTable("_ledger");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.BillId, e.StoreId, e.ObjectId }, "_ledger_BillId_IDX");

                entity.HasIndex(e => e.ObjectType, "_ledger_ObjectType_IDX");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillId).HasComment("ID lien quan. Vd: CustomerId");

                entity.Property(e => e.BillType)
                    .HasMaxLength(64)
                    .HasComment("Kieu phieu thu. Vi du: ban buon, ban le, ...");

                entity.Property(e => e.CashFlowType)
                    .HasColumnType("enum('flow_in','flow_out')")
                    .HasComment("Loai phieu thu hay chi");

                entity.Property(e => e.ContraAccountId).HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.IsActivated)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsSalesReport)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trường xác nhận phiếu thu/chi có được đưa vào báo cáo kết quả kinh doanh hay không.");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.MoneyAccountId).HasDefaultValueSql("'0'");

                entity.Property(e => e.ObjectId).HasComment("ID doi tuong");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnType("enum('other','staff','transporter','vendor','customer')")
                    .HasComment("Nhom doi tuong");

                entity.Property(e => e.RecordOrder).HasMaxLength(11);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<LedgerCategory>(entity =>
            {
                entity.ToTable("_ledger_category");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Uid, "IX_Category")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(25);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsSalesReport)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trường xác nhận phiếu thu/chi có được đưa vào báo cáo kết quả kinh doanh hay không.");

                entity.Property(e => e.IsSystem).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Type)
                    .HasColumnType("enum('in','out')")
                    .HasComment("Thu hoac Chi");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<LiabilitiesAccount>(entity =>
            {
                entity.ToTable("_liabilities_accounts");

                entity.HasComment("Quyet toan cong no: nha cung cap, nha van chuyen")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AccountingAccountId).HasComment("Tai khoan ke toan");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.LedgerId).HasComment("ID phieu chi");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.TargetId).HasComment("Depend on TargetType. Ex: CustomerId, TransporterId, VendorId");

                entity.Property(e => e.TargetType)
                    .IsRequired()
                    .HasColumnType("enum('transporter','vendor')");

                entity.Property(e => e.TotalPay)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Khach thanh toan");

                entity.Property(e => e.TotalPayTransfer)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tien chuyen sang VND");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<LiabilitiesCategory>(entity =>
            {
                entity.ToTable("_liabilities_category");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Slug, e.Type }, "UC_Category")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(25);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Type)
                    .HasColumnType("enum('in','out')")
                    .HasComment("Thu hoac Chi");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<LiabilitiesTimeline>(entity =>
            {
                entity.ToTable("_liabilities_timeline");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.TargetId, e.LedgerId, e.BillId }, "_liabilities_timeline_TargetId_IDX");

                entity.Property(e => e.AmountDecrease)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền tông nợ giảm");

                entity.Property(e => e.AmountIncrease)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền công nợ tăng");

                entity.Property(e => e.BillType).HasColumnType("enum('customer_order','vendor_order','ledger','debt_transfer','vendor_order_return','import_vendor_order','clearing_debt')");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.Expenses)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Chi phi");

                entity.Property(e => e.LedgerCategoryId).HasComment("ID Danh muc thu chi");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Cong no hien tai");

                entity.Property(e => e.LiabilitiesCategoryId).HasComment("ID Danh muc thu chi");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.TargetId).HasComment("Depend on TargetType. Ex: CustomerId, TransporterId, VendorId");

                entity.Property(e => e.TargetType)
                    .IsRequired()
                    .HasColumnType("enum('customer','transporter','vendor','staff','other')");

                entity.Property(e => e.TotalDebtReceived)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalDebtTransmitted)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalPay)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Khach thanh toan");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<LiabilitiesTimelineVendorOrder>(entity =>
            {
                entity.ToTable("_liabilities_timeline_vendor_order");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillId).HasComment("ID của kiểu hoá đơn/phiếu");

                entity.Property(e => e.BillType)
                    .HasColumnType("enum('vendor_order','import_vendor_order')")
                    .HasComment("Kiểu hoá đơn/phiếu. Giá trị enum('vendor_order', 'import_vendor_order')");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Decrease)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền giảm");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasComment("Mô tả (diễn giải)");

                entity.Property(e => e.Function)
                    .HasColumnType("enum('Add','Update','Delete')")
                    .HasComment("Chức năng");

                entity.Property(e => e.Increase)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền tăng");

                entity.Property(e => e.LiabilitiesAfter)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền công nợ sau khi tăng hoặc giảm");

                entity.Property(e => e.LiabilitiesBefore)
                    .HasPrecision(23, 2)
                    .HasComment("Công nợ trước khi update");

                entity.Property(e => e.TargetId).HasComment("ID của đối tượng cần truy vấn VendorId: 1");

                entity.Property(e => e.TargetType)
                    .HasColumnType("enum('vendor')")
                    .HasComment("Đối tượng tham chiếu");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<MediaThumbnail>(entity =>
            {
                entity.ToTable("_media_thumbnail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Url).HasMaxLength(150);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.ToTable("_media");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnType("enum('image/png','image/jpeg','image/gif')");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<MetaDatum>(entity =>
            {
                entity.ToTable("_meta_data");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Key, "Key_Index")
                    .IsUnique();

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Value).HasColumnType("text");
            });

            modelBuilder.Entity<MoneyAccount>(entity =>
            {
                entity.ToTable("_money_account");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AccountType).HasColumnType("enum('cash','bank')");

                entity.Property(e => e.BankAccountName).HasMaxLength(256);

                entity.Property(e => e.BankAccountNumber).HasMaxLength(128);

                entity.Property(e => e.BankBranch).HasMaxLength(600);

                entity.Property(e => e.BankName).HasMaxLength(256);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreditBalance)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("So du co");

                entity.Property(e => e.CurrencyCode).HasMaxLength(255);

                entity.Property(e => e.DebitBalance)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("So du no");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.IsSystemInit).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentCode).HasMaxLength(16);

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<MoneyToForeignCurrencyAccount>(entity =>
            {
                entity.ToTable("_money_to_foreign_currency_account");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AmountReceived)
                    .HasPrecision(23, 2)
                    .HasComment("Số tiền được nhận của nguồn vào");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatorId).HasComment("Người tạo");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(20)
                    .HasComment("Mã tiền tệ");

                entity.Property(e => e.EditorId).HasComment("Người sửa");

                entity.Property(e => e.ExchangRate)
                    .HasPrecision(23, 2)
                    .HasComment("Tỉ giá ngoại tệ đầu vào so với tiền tệ quốc gia ( TargetCurentcyCode [VND] )");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsExchangeRate).HasComment("Đầu vào của ngoại tệ có tỉ giá hay không");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.MoneyAccountId).HasComment("Tài khoản kế toán");

                entity.Property(e => e.SourceDate)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian của phiếu nguồn");

                entity.Property(e => e.SourceId).HasComment("Id của nguồn vào");

                entity.Property(e => e.SourceType)
                    .HasColumnType("enum('account_transfer','account_enter')")
                    .HasComment("Loại nguồn vào: enum('account_transfer', 'account_enter') v.v.v.");

                entity.Property(e => e.TotalAmountSpent)
                    .HasPrecision(23, 2)
                    .HasComment("Tổng số tiền đã chi so với số nhận từ nguồn.  TotalAmountSpent <= AmountReceived");

                entity.Property(e => e.Uuid).HasMaxLength(100);
            });

            modelBuilder.Entity<PrintQueue>(entity =>
            {
                entity.ToTable("_print_queue");

                entity.HasComment("Bảng hàng đợi in")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FileName).HasMaxLength(250);

                entity.Property(e => e.IsExcuted)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trạng thái xác định đã được xử lý");

                entity.Property(e => e.IsPrinted)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trạng thái xác định đã được in");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PrinterName).HasMaxLength(250);

                entity.Property(e => e.Priority).HasComment("Thứ tự ưu tiên");

                entity.Property(e => e.ServiceCode).HasMaxLength(64);

                entity.Property(e => e.Url).HasMaxLength(250);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("_printer");

                entity.HasComment("Bảng quản lý máy in")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DepartmentId).HasComment("Id bộ phận");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasComment("Mô tả máy in");

                entity.Property(e => e.FloorId).HasComment("ID tầng");

                entity.Property(e => e.Ip)
                    .HasMaxLength(100)
                    .HasComment("IP máy in");

                entity.Property(e => e.Label)
                    .HasMaxLength(250)
                    .HasComment("Nhãn máy in");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StaffId).HasComment("Id nhân viên");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<PrinterService>(entity =>
            {
                entity.ToTable("_printer_service");

                entity.HasComment("Bảng quản lý service máy chủ in")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasComment("Mã máy in");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .HasComment("Mô tả máy in");

                entity.Property(e => e.Ip)
                    .HasMaxLength(100)
                    .HasComment("IP máy in");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasComment("Nhãn máy in");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<PrinterServicePivot>(entity =>
            {
                entity.ToTable("_printer_service_pivot");

                entity.HasComment("Bảng mapping Service máy chủ in và Máy in. Một service sẽ được cấu hình sử dụng các máy in nào. Việc này giúp service kéo queue chính xác.")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActivated)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsDefaulted).HasComment("Máy in mặc định");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(300)
                    .HasComment("Ghi chú");

                entity.Property(e => e.PrinterId).HasComment("ID máy in");

                entity.Property(e => e.Priority).HasComment("Thứ tự ưu tiên");

                entity.Property(e => e.ServiceId).HasComment("ID bộ phận");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<PrinterTargetPivot>(entity =>
            {
                entity.ToTable("_printer_target_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActivated)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsDefaulted).HasComment("Máy in mặc định");

                entity.Property(e => e.IsMaster)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Trường xác nhận máy in này sẽ luôn được in.");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(300)
                    .HasComment("Ghi chú");

                entity.Property(e => e.PrinterId).HasComment("ID máy in");

                entity.Property(e => e.Priority).HasComment("Thứ tự ưu tiên");

                entity.Property(e => e.TargetId).HasComment("ID bộ phận");

                entity.Property(e => e.TargetType)
                    .HasColumnType("enum('department','staff')")
                    .HasComment("Nhóm đối tượng sử dụng máy in: bộ phận, nhân viên.");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("_product");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.ParentId, e.BrandId, e.CategoryId }, "_product_ParentId_IDX");

                entity.Property(e => e.AttributeFixedId).HasComment("Dải size hàng ngang");

                entity.Property(e => e.AttributeInputId).HasComment("Dải size hàng dọc");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.ParentSku).HasMaxLength(64);

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban le (Niem yet)");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban buon");

                entity.Property(e => e.Priority).HasComment("Sự ưu tiên");

                entity.Property(e => e.Quantity)
                    .HasPrecision(11, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Sku).HasMaxLength(64);

                entity.Property(e => e.SkuFromVendor).HasMaxLength(64);

                entity.Property(e => e.Slug).HasMaxLength(250);

                entity.Property(e => e.UnitId).HasComment("Id from ProductAttribute");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("_product_attribute");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.Label).HasMaxLength(250);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Priority).HasComment("sự ưu tiên");

                entity.Property(e => e.Slug).HasMaxLength(250);

                entity.Property(e => e.TypeCode).HasMaxLength(50);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<ProductAttributeGroup>(entity =>
            {
                entity.ToTable("_product_attribute_group");

                entity.HasComment("Bảng cấu hình nhóm thuộc tính. Vd: Giày gồm Size, Màu sắc")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IsDefaulted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ProductAttributeGroupPivot>(entity =>
            {
                entity.ToTable("_product_attribute_group_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductAttributePivot>(entity =>
            {
                entity.ToTable("_product_attribute_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParentProductSku).HasMaxLength(64);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductAttributeType>(entity =>
            {
                entity.ToTable("_product_attribute_type");

                entity.HasComment("Bảng định nghĩa kiểu thuộc tính. Ví dụ: Size, Màu sắc,...")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.MediaId).HasComment("Icon ID");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ShortName).HasMaxLength(250);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("_product_category");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Uid, "IX_Category")
                    .IsUnique();

                entity.HasIndex(e => new { e.Slug, e.Type }, "UC_Category")
                    .IsUnique();

                entity.Property(e => e.AttributeGroupId).HasComment("Nhom thuoc tinh");

                entity.Property(e => e.Code).HasMaxLength(25);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ParentId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Type).HasMaxLength(25);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ProductCategoryPivot>(entity =>
            {
                entity.ToTable("_product_category_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductMediaPivot>(entity =>
            {
                entity.ToTable("_product_media_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("_product_price");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost).HasPrecision(23, 2);

                entity.Property(e => e.CostLatest)
                    .HasPrecision(23, 2)
                    .HasComment("Giá nhập mới nhất");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'1.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban le (Niem yet)");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban buon");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductPriceBill>(entity =>
            {
                entity.ToTable("_product_price_bill");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasColumnType("enum('price','cost')")
                    .HasComment("Phieu gia nhap, phieu gia ban");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 4)
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.ReactiveType)
                    .IsRequired()
                    .HasColumnType("enum('auto','manual')")
                    .HasComment("Tuong tac thu cong hay tu dong");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductPriceBillDetail>(entity =>
            {
                entity.ToTable("_product_price_bill_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.DecreaseRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DecreaseWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.IncreaseRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IncreaseWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OldCost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.OldPriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.OldPriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ProductUpdateCost>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_product_update_cost");

                entity.UseCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<ProductVendorStore>(entity =>
            {
                entity.ToTable("_product_vendor_store");

                entity.HasComment("Bang du lieu ton kho theo ma NCC tai cac cua hang")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.ProductId, e.ProductParentId, e.StoreId }, "_product_vendor_store_ProductId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ProductId).HasComment("Bao gom ProductID va ProductModelId");

                entity.Property(e => e.QuantityInstock).HasPrecision(11, 2);

                entity.Property(e => e.QuantityInstockStatisticOld).HasPrecision(11, 2);

                entity.Property(e => e.QuantityLock)
                    .HasPrecision(11, 2)
                    .HasComment("So luong duoc tam giu khi ban hang (Tao don hang), chua tru ton kho chinh thuc");

                entity.Property(e => e.QuantitySlip)
                    .HasPrecision(11, 2)
                    .HasComment("Số lượng đầu kiểm kho");

                entity.Property(e => e.Sku).HasMaxLength(64);

                entity.Property(e => e.SkuFromVendor)
                    .HasMaxLength(64)
                    .HasComment("SkuFromVendor + Vendor Code");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("_province");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25)
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Type).HasMaxLength(30);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<ReportCustomerOrder>(entity =>
            {
                entity.ToTable("_report_customer_order");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gia ban");

                entity.Property(e => e.ProductVendorId)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Product ID from _product_vendor_pivot");

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.Sku).HasMaxLength(64);

                entity.Property(e => e.SkuFromVendor).HasMaxLength(64);

                entity.Property(e => e.SkuVendor).HasMaxLength(64);

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("_slide");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Link).HasMaxLength(125);

                entity.Property(e => e.LinkText).HasMaxLength(125);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<StatisticAccountingDay>(entity =>
            {
                entity.ToTable("_statistic_accounting_days");

                entity.HasComment("Bảng thống kê quỹ tiền ( Tài khoản kế toán ) theo ngày")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AccountId).HasComment("Id tài khoảng kế toán");

                entity.Property(e => e.CashBookIn)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số tiền thu trong kỳ");

                entity.Property(e => e.CashBookOut)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số tiền chi trong kỳ");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PeriodEnd)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số tiền cuối kỳ");

                entity.Property(e => e.PeriodStart)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số tiền đầu kỳ");

                entity.Property(e => e.StatisticDate).HasComment("Ngày thông kê");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("_status");

                entity.HasComment("Bảng định nghĩa kiểu thuộc tính. Ví dụ: Size, Màu sắc,...")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.Color).HasMaxLength(7);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CssClass).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.MediaId).HasComment("Icon ID");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<StatusGroup>(entity =>
            {
                entity.ToTable("_status_group");

                entity.HasComment("Bảng cấu hình nhóm thuộc tính. Vd: Giày gồm Size, Màu sắc")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IsDefaulted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<StatusGroupPivot>(entity =>
            {
                entity.ToTable("_status_group_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("_store");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.Fax).HasMaxLength(25);

                entity.Property(e => e.Hotline).HasMaxLength(25);

                entity.Property(e => e.ManagerId).HasComment("QuÃƒÂ¡Ã‚ÂºÃ‚Â£n lÃƒÆ’Ã‚Â½ kho/cÃƒÂ¡Ã‚Â»Ã‚Â­a hÃƒÆ’Ã‚Â ng");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasDefaultValueSql("'uuid()'");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<StoreArea>(entity =>
            {
                entity.ToTable("_store_area");

                entity.HasComment("Khu vực của cửa hàng. Ví dụ: Tầng 1, tầng 2, tầng 3; Khu 1, khu 2 , khu 3,...")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasComment("Mô tả khu vực");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .HasComment("Mã nhóm khu vực. Ví dụ: floor, zone,...");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasComment("Tên khu vực");

                entity.Property(e => e.Priority).HasComment("Thứ tự ưu tiên");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<StoreOrder>(entity =>
            {
                entity.ToTable("_store_order");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.TransporterId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<StoreOrderDetail>(entity =>
            {
                entity.ToTable("_store_order_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost).HasPrecision(23, 4);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountCash).HasPrecision(23, 4);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ProductVendorId)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Product ID from _product_vendor_pivot");

                entity.Property(e => e.Quantity)
                    .HasColumnType("float(11,0)")
                    .HasComment("Import quantity");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.SkuVendor).HasMaxLength(64);

                entity.Property(e => e.StoreOrderId).HasComment("ID from _vendor_order");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemDataRole>(entity =>
            {
                entity.ToTable("_system_data_role");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.DataId, e.AccountId }, "_system_data_role_DataId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StatusCode).HasMaxLength(32);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemDataRoleFullPermission>(entity =>
            {
                entity.ToTable("_system_data_role_full_permission");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DataType).HasMaxLength(64);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StatusCode).HasMaxLength(32);

                entity.Property(e => e.TargetId).HasComment("ID Doi tuong duoc thiet lap, vi du: Bo phan, Tai khoan");

                entity.Property(e => e.TargetType)
                    .HasColumnType("enum('department','account')")
                    .HasComment("Nhom doi tuong duoc thiet lap, vi du: Bo phan, Tai khoan");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemModule>(entity =>
            {
                entity.ToTable("_system_module");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.ToTable("_system_role");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasColumnType("enum('get','post','put','delete')");

                entity.Property(e => e.ControllerType).HasColumnType("enum('api','page')");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CssClass).HasMaxLength(100);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Icon).HasMaxLength(100);

                entity.Property(e => e.IsShowMenu).HasDefaultValueSql("'0'");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Priority).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable("_system_user");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Gender).HasColumnType("enum('male','female','other')");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OneSignalPlayerId)
                    .HasMaxLength(64)
                    .HasComment("Player ID trên OneSignal sử dụng để push notification.");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ShopId).HasComment("Id cửa hàng/gian hàng/công ty/đơn vị,...");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemUserGroupPivot>(entity =>
            {
                entity.ToTable("_system_user_group_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemUserMoneyAccountPivot>(entity =>
            {
                entity.ToTable("_system_user_money_account_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<SystemUserRolePivot>(entity =>
            {
                entity.ToTable("_system_user_role_pivot");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.GroupId, e.UserId, e.RoleId }, "_system_user_role_pivot_GroupId_IDX");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Taxonomy>(entity =>
            {
                entity.ToTable("_taxonomy");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TaxonomyTerm>(entity =>
            {
                entity.ToTable("_taxonomy_term");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.IsDeleted, "IsDeleted_Index");

                entity.HasIndex(e => e.TaxonomyId, "Taxonomy_Index");

                entity.HasIndex(e => new { e.TaxonomyId, e.Slug }, "Taxonomy_Slug_Unique")
                    .IsUnique();

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Data).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(155);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(64)
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TemplateTable>(entity =>
            {
                entity.ToTable("_template_table");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Priority).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ThanhToanNcc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_thanh_toan_ncc");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IdPhieuChi).HasMaxLength(8);

                entity.Property(e => e.NgayThang).HasMaxLength(10);

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(42)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<Transporter>(entity =>
            {
                entity.ToTable("_transporter");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CountryId)
                    .HasDefaultValueSql("'235'")
                    .HasComment("ID quoc gia, mac dinh la Viet Nam");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Cong no hien tai");

                entity.Property(e => e.MaxLiabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Gioi han cong no cho phep");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<TransporterPrice>(entity =>
            {
                entity.ToTable("_transporter_price");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'1.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(64)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<TransporterPriceBill>(entity =>
            {
                entity.ToTable("_transporter_price_bill");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.ReactiveType)
                    .IsRequired()
                    .HasColumnType("enum('auto','manual')")
                    .HasDefaultValueSql("'manual'")
                    .HasComment("Tuong tac thu cong hay tu dong");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.TransporterId).HasComment("ID nha van chuyen");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<TransporterPriceBillDetail>(entity =>
            {
                entity.ToTable("_transporter_price_bill_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.DecreasePrice)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.IncreasePrice)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OldPrice)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<TransporterVendorOrderBill>(entity =>
            {
                entity.ToTable("_transporter_vendor_order_bill");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.BillCode).HasMaxLength(64);

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ImportVendorId).HasComment("Id nhập hàng từ nhà cung cấp");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.ReactiveType)
                    .HasColumnType("enum('auto','manual')")
                    .HasDefaultValueSql("'manual'")
                    .HasComment("Tuong tac thu cong hay tu dong");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalQuantity).HasPrecision(11, 2);

                entity.Property(e => e.TransporterId).HasComment("ID nha van chuyen");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<TransporterVendorOrderBillDetail>(entity =>
            {
                entity.ToTable("_transporter_vendor_order_bill_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantity).HasPrecision(23, 2);

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("_user_group");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Editor).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('E','M','A','SA')");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("_vendor");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.BeginningLiabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Công nợ đầu kỳ");

                entity.Property(e => e.CnDauKy)
                    .HasPrecision(25, 2)
                    .HasColumnName("CN_DauKy");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IsMigrate).HasDefaultValueSql("'0'");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 4)
                    .HasComment("Cong no hien tai");

                entity.Property(e => e.LiabilitiesImport)
                    .HasPrecision(23, 2)
                    .HasComment("Công nợ nhập hàng từ nhà cung cấp");

                entity.Property(e => e.LiabilitiesOrder)
                    .HasPrecision(23, 2)
                    .HasComment("Công nơ đặt hàng từ nhà cung cấp");

                entity.Property(e => e.MaxLiabilities)
                    .HasPrecision(23, 4)
                    .HasComment("Gioi han cong no cho phep");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.TotalQuantityImported)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng sản phẩm đã nhập hàng");

                entity.Property(e => e.TotalQuantityOrdered)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng sản phẩm đặt hàng");

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<VendorOrder>(entity =>
            {
                entity.ToTable("_vendor_order");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.AttributeTemplateId).HasComment("Input form type");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(16)
                    .HasComment("Dong tien su dung");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.GrandTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tien sau khi tinh toan thue, van chuyen, ...");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.NoteInternal).HasMaxLength(600);

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.OrderStatusCode).HasMaxLength(64);

                entity.Property(e => e.OrderTransactionType)
                    .HasColumnType("enum('change_type','return_type','primary_type')")
                    .HasDefaultValueSql("'primary_type'")
                    .HasComment("Chinh thuc, tra hang, doi hang");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tam tinh thanh tien tren cac items");

                entity.Property(e => e.Tax)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tien thue");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tong tien sau khi tru di discount");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TransportFee)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Phi van chuyen");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<VendorOrderDetail>(entity =>
            {
                entity.ToTable("_vendor_order_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.ProductModelId, e.ParentProductId, e.VendorOrderId }, "_vendor_order_detail_ProductModelId_IDX");

                entity.Property(e => e.AttributeTemplateId).HasComment("Input form type");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(32)
                    .HasComment("Don vi tien te. Vi du: VND, CNY");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Ty gia. Vi du: 1CNY = 3600 VND");

                entity.Property(e => e.IsExtraImport).HasComment("Trang thai san pham nhap khong nam trong danh sach dat hang NCC");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.VendorOrderId).HasComment("ID from _vendor_order");
            });

            modelBuilder.Entity<VendorOrderDetailV2>(entity =>
            {
                entity.ToTable("_vendor_order_detail_v2");

                entity.HasComment("Chi tiết đặt hàng từ nhà cung cấp version2")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá nhập");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatorId).HasComment("Người tạo");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(16)
                    .HasComment("Tiền tệ.  Mã tiền tệ theo quốc gia");

                entity.Property(e => e.EditorId).HasComment("Người sửa");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(11, 2)
                    .HasComment("giá đón quy đổi ra VND");

                entity.Property(e => e.IsDeleted).HasComment("không xoá: 0, Xoá: 1");

                entity.Property(e => e.IsExtraImport).HasComment("Trạng thái sản phẩm không nằm trong Danh sách đặt hàng ban đầu mà được Thêm khi sửa đơn đặt");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParentProductId).HasComment("Sản phẩm cha đặt NCC ( Null khi sản phẩm chưa tồn tại)");

                entity.Property(e => e.PriceRetail)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá bản lẻ của sản phẩm");

                entity.Property(e => e.PriceWholesale)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Giá bán buôn");

                entity.Property(e => e.Quantity)
                    .HasPrecision(11, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số lượng đặt");

                entity.Property(e => e.QuantityImported)
                    .HasPrecision(11, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số lượng đã nhập");

                entity.Property(e => e.QuantityInit)
                    .HasPrecision(11, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Số lượng đặt lần đầu");

                entity.Property(e => e.SkuFromVendor)
                    .HasMaxLength(64)
                    .HasComment("Mã sản phẩm đặt hàng từ nhà cung cấp");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(64)
                    .HasComment("\"- Tình trạng Mã hàng:\n1. Chưa nhập: waiting_import\n2. Thiếu hàng: quantity_missing\n3. Đủ hàng: quantity_completed\n4. Thừa hàng: quantity_more\"");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(64)
                    .HasComment("Trạng thái đơn đặt:");

                entity.Property(e => e.StoreId).HasComment("Id cửa hàng");

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasComment("- Tổng tiền của sản phẩm.");

                entity.Property(e => e.SubTotalImported)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tổng số tiền đã nhập");

                entity.Property(e => e.TransporterId).HasComment("Id nhà vận chuyển");

                entity.Property(e => e.Uuid).HasMaxLength(100);

                entity.Property(e => e.VendorId).HasComment("Id nhà cung cấp");

                entity.Property(e => e.VendorOrderCode)
                    .HasMaxLength(64)
                    .HasComment("Mã Order của đơn đặt hàng");

                entity.Property(e => e.VendorOrderDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày giờ đặt hàng");

                entity.Property(e => e.VendorOrderId).HasComment("Id đơn đặt hàng. Reference bảng _vendor_order_v2");
            });

            modelBuilder.Entity<VendorOrderReturn>(entity =>
            {
                entity.ToTable("_vendor_order_return");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.VendorId, e.StoreId }, "_customer_order_CustomerId_IDX");

                entity.Property(e => e.CompletedTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian xác nhận hoàn tất đơn.");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasComment("Mã đơn vị tiền tệ.");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.GrandTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tien sau khi tinh toan thue, van chuyen, ...");

                entity.Property(e => e.Liabilities)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note).HasMaxLength(600);

                entity.Property(e => e.NoteInternal).HasMaxLength(600);

                entity.Property(e => e.OrderCode).HasMaxLength(64);

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.StatusCode).HasMaxLength(64);

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tam tinh thanh tien tren cac items");

                entity.Property(e => e.Tax)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tien thue");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Thanh tong tien sau khi tru di discount");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TransporterId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Uid).HasMaxLength(64);

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<VendorOrderReturnDetail>(entity =>
            {
                entity.ToTable("_vendor_order_return_detail");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.HasIndex(e => new { e.VendorOrderReturnId, e.ParentProductId, e.ProductModelId }, "_customer_order_detail_CustomerOrderId_IDX");

                entity.Property(e => e.Cost)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(11, 2)
                    .HasComment("Tỷ giá đón quy đổi ra VND");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Quantity)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Import quantity");

                entity.Property(e => e.Sku).HasMaxLength(64);

                entity.Property(e => e.SkuFromVendor).HasMaxLength(64);

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.Version).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<VendorOrderV2>(entity =>
            {
                entity.ToTable("_vendor_order_v2");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(16)
                    .HasComment("Tiền tệ.  Mã tiền tệ theo quốc gia");

                entity.Property(e => e.DiscountCash)
                    .HasPrecision(23, 2)
                    .HasComment("Giảm giá theo tiền mặt");

                entity.Property(e => e.DiscountPercent)
                    .HasPrecision(11, 2)
                    .HasComment("Giảm giá %");

                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(11, 2)
                    .HasComment("giá đón quy đổi ra VND");

                entity.Property(e => e.GrandTotal)
                    .HasPrecision(23, 2)
                    .HasComment("- Thành tiền sau tất cả chi phí đơn hàng. ");

                entity.Property(e => e.GrandTotalImported)
                    .HasPrecision(23, 2)
                    .HasComment("- Thành tiền sau tất cả chi phí đơn hàng. ");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasMaxLength(600)
                    .HasComment("Ghi chú đơn đặt");

                entity.Property(e => e.NoteInternal)
                    .HasMaxLength(600)
                    .HasComment("Ghi chú đơn nhập cho nội bộ");

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(64)
                    .HasComment("Mã đơn hang");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian đặt ghi nhận đặt hàng");

                entity.Property(e => e.RecordOrder)
                    .HasMaxLength(7)
                    .HasComment("So thu tu bill");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(64)
                    .HasComment("\"- Tình trạng đơn hàng:\n1. Chưa nhập: waiting_import\n2. Thiếu hàng: quantity_missing\n3. Đủ hàng: quantity_completed\n4. Thừa hàng: quantity_more\"");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(64)
                    .HasComment("Trạng thái đơn đặt.:\r\n1. Chờ nhập : waiting_import\r\n2. Thiếu hàng: quantity_missing\r\n3. Đủ hàng: quantity_completed\r\n4. Thừa hàng: quantity_more\r\n5. Hoàn thành: completed");

                entity.Property(e => e.StoreId).HasComment("id cửa hàng");

                entity.Property(e => e.SubTotal)
                    .HasPrecision(23, 2)
                    .HasComment("- Tạm tính tiền đơn đặt.");

                entity.Property(e => e.SubTotalImported)
                    .HasPrecision(23, 2)
                    .HasComment("- Tạm tính tiền đơn đặt đã nhập");

                entity.Property(e => e.SubTotalInit)
                    .HasPrecision(23, 2)
                    .HasComment("\"- Tạm tính tiền đơn đặt khi tạo đơn đặt");

                entity.Property(e => e.TimeFinalAccounts)
                    .HasColumnType("datetime")
                    .HasComment("thời gian quyết toán đơn hàng");

                entity.Property(e => e.Total)
                    .HasPrecision(23, 2)
                    .HasComment("- Tổng tiền sau chiết khấu: ");

                entity.Property(e => e.TotalAmountPaid)
                    .HasPrecision(23, 2)
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Tổng số tiền đã");

                entity.Property(e => e.TotalImported)
                    .HasPrecision(23, 2)
                    .HasComment("- Công thức: TotalImported= (SubTotalImported - DiscountCash) - ( SubTotalImported *DiscountPercent / 100)");

                entity.Property(e => e.TotalQuantity)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng đặt");

                entity.Property(e => e.TotalQuantityImported)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng đã nhập của đơn đặt");

                entity.Property(e => e.TotalQuantityInit)
                    .HasPrecision(11, 2)
                    .HasComment("Tổng số lượng khi tạo đơn ( không cập nhật khi sửa đơn )");

                entity.Property(e => e.TransporterId).HasComment("ID nhà vận chuyển");

                entity.Property(e => e.Uuid).HasMaxLength(64);

                entity.Property(e => e.VendorId).HasComment("Id nhà cung cấp");

                entity.Property(e => e.Version).HasComment("Version bản ghi");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("_video");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(25);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("_ward");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Location).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(30);

                entity.Property(e => e.Uuid).HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
