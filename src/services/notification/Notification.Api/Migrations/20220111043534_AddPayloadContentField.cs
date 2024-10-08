using Microsoft.EntityFrameworkCore.Migrations;

namespace Notification.Api.Migrations
{
    public partial class AddPayloadContentField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "payload",
                schema: "notification",
                table: "notification_histories",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payload",
                schema: "notification",
                table: "notification_histories");
        }
    }
}
