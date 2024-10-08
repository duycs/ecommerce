using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_number = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_name = table.Column<string>(type: "text", nullable: true),
                    customer_phone = table.Column<string>(type: "text", nullable: true),
                    customer_address = table.Column<string>(type: "text", nullable: true),
                    province_id = table.Column<Guid>(type: "uuid", nullable: true),
                    province_name = table.Column<string>(type: "text", nullable: true),
                    district_id = table.Column<Guid>(type: "uuid", nullable: true),
                    district_name = table.Column<string>(type: "text", nullable: true),
                    ward_id = table.Column<Guid>(type: "uuid", nullable: true),
                    ward_name = table.Column<string>(type: "text", nullable: true),
                    discount_price = table.Column<decimal>(type: "numeric", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    date_time_order = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    staff_phone = table.Column<string>(type: "text", nullable: true),
                    staff_name = table.Column<string>(type: "text", nullable: true),
                    saas_code = table.Column<string>(type: "text", nullable: true),
                    payment_method = table.Column<string>(type: "text", nullable: true),
                    carriage_number = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_updated_by = table.Column<string>(type: "text", nullable: true),
                    last_updated_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    discount_price = table.Column<decimal>(type: "numeric", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_sku = table.Column<string>(type: "text", nullable: true),
                    product_name = table.Column<string>(type: "text", nullable: true),
                    product_child_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_child_name = table.Column<string>(type: "text", nullable: true),
                    product_child_sku = table.Column<string>(type: "text", nullable: true),
                    product_image = table.Column<string>(type: "text", nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    brand_name = table.Column<string>(type: "text", nullable: true),
                    product_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_category_name = table.Column<string>(type: "text", nullable: true),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_name = table.Column<string>(type: "text", nullable: true),
                    attribute_values = table.Column<string>(type: "jsonb", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_updated_by = table.Column<string>(type: "text", nullable: true),
                    last_updated_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_details_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "order",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_details_order_id",
                schema: "order",
                table: "order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_saas_code",
                schema: "order",
                table: "orders",
                column: "saas_code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details",
                schema: "order");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "order");
        }
    }
}
