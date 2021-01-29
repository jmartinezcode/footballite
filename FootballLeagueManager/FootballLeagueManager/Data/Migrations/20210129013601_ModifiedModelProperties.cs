using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeagueManager.Data.Migrations
{
    public partial class ModifiedModelProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c392353f-87d3-4597-b617-46727a4370b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c3f0753-756a-4d5b-98ec-004efa919239", "f210e34b-5ee7-48f3-8747-5c2f905e8f2f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c3f0753-756a-4d5b-98ec-004efa919239");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c392353f-87d3-4597-b617-46727a4370b5", "61473ef0-e3fb-48db-8b63-4144e61ea397", "Admin", "ADMIN" });
        }
    }
}
