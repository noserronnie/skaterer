using Microsoft.EntityFrameworkCore.Migrations;

namespace Skateshop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeckProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Wheelbase = table.Column<float>(type: "real", nullable: false),
                    Nose = table.Column<float>(type: "real", nullable: false),
                    Tail = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckProduct_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GriptapeProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GriptapeProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GriptapeProduct_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrucksProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AxleWidth = table.Column<float>(type: "real", nullable: false),
                    HangerWidth = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrucksProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrucksProduct_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WheelsProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Hardness = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelsProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheelsProduct_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingCartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeckProductShoppingCart",
                columns: table => new
                {
                    DeckProductsId = table.Column<long>(type: "bigint", nullable: false),
                    ShoppingCartsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckProductShoppingCart", x => new { x.DeckProductsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_DeckProductShoppingCart_DeckProduct_DeckProductsId",
                        column: x => x.DeckProductsId,
                        principalTable: "DeckProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckProductShoppingCart_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GriptapeProductShoppingCart",
                columns: table => new
                {
                    GriptapeProductsId = table.Column<long>(type: "bigint", nullable: false),
                    ShoppingCartsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GriptapeProductShoppingCart", x => new { x.GriptapeProductsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_GriptapeProductShoppingCart_GriptapeProduct_GriptapeProductsId",
                        column: x => x.GriptapeProductsId,
                        principalTable: "GriptapeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GriptapeProductShoppingCart_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartTrucksProduct",
                columns: table => new
                {
                    ShoppingCartsId = table.Column<long>(type: "bigint", nullable: false),
                    TrucksProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartTrucksProduct", x => new { x.ShoppingCartsId, x.TrucksProductsId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartTrucksProduct_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartTrucksProduct_TrucksProduct_TrucksProductsId",
                        column: x => x.TrucksProductsId,
                        principalTable: "TrucksProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartWheelsProduct",
                columns: table => new
                {
                    ShoppingCartsId = table.Column<long>(type: "bigint", nullable: false),
                    WheelsProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartWheelsProduct", x => new { x.ShoppingCartsId, x.WheelsProductsId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartWheelsProduct_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartWheelsProduct_WheelsProduct_WheelsProductsId",
                        column: x => x.WheelsProductsId,
                        principalTable: "WheelsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckProduct_BrandId",
                table: "DeckProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckProductShoppingCart_ShoppingCartsId",
                table: "DeckProductShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_GriptapeProduct_BrandId",
                table: "GriptapeProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GriptapeProductShoppingCart_ShoppingCartsId",
                table: "GriptapeProductShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTrucksProduct_TrucksProductsId",
                table: "ShoppingCartTrucksProduct",
                column: "TrucksProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartWheelsProduct_WheelsProductsId",
                table: "ShoppingCartWheelsProduct",
                column: "WheelsProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrucksProduct_BrandId",
                table: "TrucksProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ShoppingCartId",
                table: "User",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_WheelsProduct_BrandId",
                table: "WheelsProduct",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckProductShoppingCart");

            migrationBuilder.DropTable(
                name: "GriptapeProductShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCartTrucksProduct");

            migrationBuilder.DropTable(
                name: "ShoppingCartWheelsProduct");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DeckProduct");

            migrationBuilder.DropTable(
                name: "GriptapeProduct");

            migrationBuilder.DropTable(
                name: "TrucksProduct");

            migrationBuilder.DropTable(
                name: "WheelsProduct");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
