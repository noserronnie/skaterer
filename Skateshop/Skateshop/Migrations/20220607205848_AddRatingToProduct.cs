using Microsoft.EntityFrameworkCore.Migrations;

namespace Skateshop.Migrations
{
    public partial class AddRatingToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "WheelsProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TrucksProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "GriptapeProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "DeckProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "WheelsProduct");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TrucksProduct");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "GriptapeProduct");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "DeckProduct");
        }
    }
}
