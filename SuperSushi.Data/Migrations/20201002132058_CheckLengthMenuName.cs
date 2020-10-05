using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperSushi.Data.Migrations
{
    public partial class CheckLengthMenuName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Menus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Gerechten",
                columns: new[] { "Id", "Omschrijving", "Prijs", "Soort" },
                values: new object[,]
                {
                    { 1, "Maki Tuna", 0m, 0 },
                    { 2, "Sashimi Salmon", 0m, 0 },
                    { 3, "Caramelised Crickets ", 0m, 3 },
                    { 4, "Cinnamon Worms", 0m, 3 },
                    { 5, "Nigiri Tofu", 0m, 2 },
                    { 6, "Gunkam Zeewier", 0m, 2 },
                    { 7, "Tebasaki Kip", 0m, 1 },
                    { 8, "Teriyaki Biefstuk", 0m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "KortingPercentage", "Naam" },
                values: new object[,]
                {
                    { 1, 0, "Smells Fishy" },
                    { 2, 0, "Bunny Bugs" },
                    { 3, 0, "Mighty Meaty" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
