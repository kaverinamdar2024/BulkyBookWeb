using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    public partial class SeedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catogories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 1, 1, "Action" });

            migrationBuilder.InsertData(
                table: "Catogories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 2, 2, "SciFi" });

            migrationBuilder.InsertData(
                table: "Catogories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 3, 3, "History" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Catogories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catogories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catogories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
