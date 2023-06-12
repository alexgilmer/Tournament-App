using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DescriptionVisible",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParentAnswerId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ParentAnswerId",
                table: "Answers",
                column: "ParentAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Answers_ParentAnswerId",
                table: "Answers",
                column: "ParentAnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Answers_ParentAnswerId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_ParentAnswerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "DescriptionVisible",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ParentAnswerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Answers");
        }
    }
}
