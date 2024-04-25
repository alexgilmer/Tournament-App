using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswerBankFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FeatureControls",
                columns: new[] { "Name", "IsEnabled" },
                values: new object[] { "Answer Bank", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeatureControls",
                keyColumn: "Name",
                keyValue: "Answer Bank");
        }
    }
}
