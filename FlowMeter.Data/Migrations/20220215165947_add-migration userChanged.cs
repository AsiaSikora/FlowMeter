using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMeter.Data.Migrations
{
    public partial class addmigrationuserChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Localizations_LocalizationId",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalizationId",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Localizations_LocalizationId",
                table: "Surveys",
                column: "LocalizationId",
                principalTable: "Localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Localizations_LocalizationId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "LocalizationId",
                table: "Surveys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Localizations_LocalizationId",
                table: "Surveys",
                column: "LocalizationId",
                principalTable: "Localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
