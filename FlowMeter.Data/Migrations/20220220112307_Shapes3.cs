using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMeter.Data.Migrations
{
    public partial class Shapes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalizationId",
                table: "Shapes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShapeId",
                table: "Localizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shapes_LocalizationId",
                table: "Shapes",
                column: "LocalizationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shapes_Localizations_LocalizationId",
                table: "Shapes",
                column: "LocalizationId",
                principalTable: "Localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shapes_Localizations_LocalizationId",
                table: "Shapes");

            migrationBuilder.DropIndex(
                name: "IX_Shapes_LocalizationId",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "LocalizationId",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "Localizations");
        }
    }
}
