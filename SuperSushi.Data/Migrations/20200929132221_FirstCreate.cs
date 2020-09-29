using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperSushi.Data.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gerechten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<int>(nullable: false),
                    Omschrijving = table.Column<string>(maxLength: 150, nullable: true),
                    Prijs = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerechten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    KortingPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuGerechten",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    GerechtId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGerechten", x => new { x.GerechtId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuGerechten_Gerechten_GerechtId",
                        column: x => x.GerechtId,
                        principalTable: "Gerechten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuGerechten_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuGerechten_MenuId",
                table: "MenuGerechten",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuGerechten");

            migrationBuilder.DropTable(
                name: "Gerechten");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
