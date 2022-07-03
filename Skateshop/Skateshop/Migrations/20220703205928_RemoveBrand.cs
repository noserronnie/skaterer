using Microsoft.EntityFrameworkCore.Migrations;

namespace Skaterer.Migrations
{
    public partial class RemoveBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckProduct_Brand_BrandId",
                table: "DeckProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_GriptapeProduct_Brand_BrandId",
                table: "GriptapeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TrucksProduct_Brand_BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_WheelsProduct_Brand_BrandId",
                table: "WheelsProduct");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_WheelsProduct_BrandId",
                table: "WheelsProduct");

            migrationBuilder.DropIndex(
                name: "IX_TrucksProduct_BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropIndex(
                name: "IX_GriptapeProduct_BrandId",
                table: "GriptapeProduct");

            migrationBuilder.DropIndex(
                name: "IX_DeckProduct_BrandId",
                table: "DeckProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "WheelsProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "GriptapeProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "DeckProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "WheelsProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "TrucksProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "GriptapeProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "DeckProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheelsProduct_BrandId",
                table: "WheelsProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TrucksProduct_BrandId",
                table: "TrucksProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GriptapeProduct_BrandId",
                table: "GriptapeProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckProduct_BrandId",
                table: "DeckProduct",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckProduct_Brand_BrandId",
                table: "DeckProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GriptapeProduct_Brand_BrandId",
                table: "GriptapeProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrucksProduct_Brand_BrandId",
                table: "TrucksProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WheelsProduct_Brand_BrandId",
                table: "WheelsProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
