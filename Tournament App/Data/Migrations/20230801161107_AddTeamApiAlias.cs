using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamApiAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiAlias",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ApiAlias",
                table: "Teams",
                column: "ApiAlias",
                unique: true,
                filter: "[ApiAlias] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_ApiAlias",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ApiAlias",
                table: "Teams");
        }
    }
}
