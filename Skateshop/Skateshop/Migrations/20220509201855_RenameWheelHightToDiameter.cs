using Microsoft.EntityFrameworkCore.Migrations;

namespace Skateshop.Migrations
{
    public partial class RenameWheelHightToDiameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Height",
                table: "WheelsProduct",
                newName: "Diameter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diameter",
                table: "WheelsProduct",
                newName: "Height");
        }
    }
}
