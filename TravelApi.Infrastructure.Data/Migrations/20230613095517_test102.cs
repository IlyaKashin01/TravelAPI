using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_CarId",
                table: "person");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "person",
                newName: "car_id");

            migrationBuilder.RenameIndex(
                name: "IX_person_CarId",
                table: "person",
                newName: "IX_person_car_id");

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_car_id",
                table: "person",
                column: "car_id",
                principalTable: "car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_car_id",
                table: "person");

            migrationBuilder.RenameColumn(
                name: "car_id",
                table: "person",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_person_car_id",
                table: "person",
                newName: "IX_person_CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_CarId",
                table: "person",
                column: "CarId",
                principalTable: "car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
