using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "integration");

            migrationBuilder.CreateTable(
                name: "attribute_mappings",
                schema: "integration",
                columns: table => new
                {
                    attribute_value_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attribute_mappings", x => x.attribute_value_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_mappings",
                schema: "integration",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_mappings", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "category_mappings",
                schema: "integration",
                columns: table => new
                {
                    old_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_mappings", x => x.old_id);
                });

            migrationBuilder.CreateTable(
                name: "child_product_mappings",
                schema: "integration",
                columns: table => new
                {
                    child_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_child_product_mappings", x => x.child_product_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_mappings",
                schema: "integration",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_mappings", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "order_mappings",
                schema: "integration",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_mappings", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "product_mappings",
                schema: "integration",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_mappings", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "system_logs",
                schema: "integration",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    contents = table.Column<string>(type: "jsonb", nullable: true),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_logs", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_brand_mappings_old_id",
                schema: "integration",
                table: "brand_mappings",
                column: "old_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_child_product_mappings_old_id",
                schema: "integration",
                table: "child_product_mappings",
                column: "old_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_mappings_old_id",
                schema: "integration",
                table: "customer_mappings",
                column: "old_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_mappings_old_id",
                schema: "integration",
                table: "order_mappings",
                column: "old_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_mappings_old_id",
                schema: "integration",
                table: "product_mappings",
                column: "old_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attribute_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "brand_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "category_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "child_product_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "customer_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "order_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "product_mappings",
                schema: "integration");

            migrationBuilder.DropTable(
                name: "system_logs",
                schema: "integration");
        }
    }
}
