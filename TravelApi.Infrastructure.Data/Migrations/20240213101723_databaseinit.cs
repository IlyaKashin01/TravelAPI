using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class databaseinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "verified_email",
                table: "person",
                newName: "verified");

            migrationBuilder.RenameColumn(
                name: "is_verified_email",
                table: "person",
                newName: "is_verified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "verified",
                table: "person",
                newName: "verified_email");

            migrationBuilder.RenameColumn(
                name: "is_verified",
                table: "person",
                newName: "is_verified_email");
        }
    }
}
