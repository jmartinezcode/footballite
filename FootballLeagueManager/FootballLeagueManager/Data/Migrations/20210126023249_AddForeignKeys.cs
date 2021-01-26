using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeagueManager.Data.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b78a25-1d71-48ee-8956-df7487f51a2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1da2353a-1cd0-4b4d-b791-43213a002c37", "4fbac900-ae33-4154-867d-36b5cac7c5e3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da2353a-1cd0-4b4d-b791-43213a002c37");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7b78a25-1d71-48ee-8956-df7487f51a2f", "c70c25c9-94a1-45cb-9f9f-86743c6da901", "Admin", "ADMIN" });
        }
    }
}
