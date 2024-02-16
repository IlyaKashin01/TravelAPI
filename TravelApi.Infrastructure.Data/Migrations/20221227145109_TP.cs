using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class TP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Journeys_CategoryId",
                table: "Journeys");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_CategoryId",
                table: "Journeys",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Journeys_CategoryId",
                table: "Journeys");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_CategoryId",
                table: "Journeys",
                column: "CategoryId",
                unique: true);
        }
    }
}
