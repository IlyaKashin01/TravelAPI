using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_car_id",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_car_id",
                table: "person");

            migrationBuilder.DropColumn(
                name: "car_id",
                table: "person");

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "car",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_car_person_id",
                table: "car",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_person_person_id",
                table: "car",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_person_person_id",
                table: "car");

            migrationBuilder.DropIndex(
                name: "IX_car_person_id",
                table: "car");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "car");

            migrationBuilder.AddColumn<int>(
                name: "car_id",
                table: "person",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_car_id",
                table: "person",
                column: "car_id");

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_car_id",
                table: "person",
                column: "car_id",
                principalTable: "car",
                principalColumn: "Id");
        }
    }
}
