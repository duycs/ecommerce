using Microsoft.EntityFrameworkCore.Migrations;

namespace Notification.Api.Migrations
{
    public partial class AddNotificationHistoryTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "notification",
                table: "notification_histories",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                schema: "notification",
                table: "notification_histories");
        }
    }
}
