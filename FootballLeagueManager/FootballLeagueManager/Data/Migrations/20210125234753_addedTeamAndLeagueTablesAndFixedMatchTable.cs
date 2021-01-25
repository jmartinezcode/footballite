using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeagueManager.Data.Migrations
{
    public partial class addedTeamAndLeagueTablesAndFixedMatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3433f6cc-574f-4b72-8563-94c8fee65440");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7b78a25-1d71-48ee-8956-df7487f51a2f", "c70c25c9-94a1-45cb-9f9f-86743c6da901", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b78a25-1d71-48ee-8956-df7487f51a2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3433f6cc-574f-4b72-8563-94c8fee65440", "4c942249-f165-4c9e-b983-83fca6d3c803", "Admin", "ADMIN" });
        }
    }
}
