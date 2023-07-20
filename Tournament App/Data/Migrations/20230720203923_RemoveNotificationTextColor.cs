using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotificationTextColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextColor",
                table: "Notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextColor",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
