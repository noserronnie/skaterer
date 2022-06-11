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

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<long>(type: "bigint", nullable: true),
                    Stars = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AuthorId",
                table: "Rating",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

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
