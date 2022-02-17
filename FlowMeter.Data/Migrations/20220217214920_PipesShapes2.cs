using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMeter.Data.Migrations
{
    public partial class PipesShapes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "LengthA",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "LengthB",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Radius",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "Trapeze_Height",
                table: "Shapes");

            migrationBuilder.DropColumn(
                name: "MedianFlow",
                table: "Measurements");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Pressure",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CurrentFlow",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AverageFlow",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GpsCoordinate2",
                table: "Localizations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GpsCoordinate1",
                table: "Localizations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circles_Shapes_Id",
                        column: x => x.Id,
                        principalTable: "Shapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lenght = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangles_Shapes_Id",
                        column: x => x.Id,
                        principalTable: "Shapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trapeziums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LengthA = table.Column<double>(type: "float", nullable: true),
                    LengthB = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trapeziums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trapeziums_Shapes_Id",
                        column: x => x.Id,
                        principalTable: "Shapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.DropTable(
                name: "Trapeziums");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Shapes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lenght",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LengthA",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LengthB",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Radius",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Trapeze_Height",
                table: "Shapes",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "Measurements",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Pressure",
                table: "Measurements",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CurrentFlow",
                table: "Measurements",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AverageFlow",
                table: "Measurements",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "MedianFlow",
                table: "Measurements",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GpsCoordinate2",
                table: "Localizations",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GpsCoordinate1",
                table: "Localizations",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
