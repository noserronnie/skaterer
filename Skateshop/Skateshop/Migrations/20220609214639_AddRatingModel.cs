using Microsoft.EntityFrameworkCore.Migrations;

namespace Skaterer.Migrations
{
    public partial class AddRatingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "WheelsProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "TrucksProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "GriptapeProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "DeckProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
