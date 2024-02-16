using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_car_id",
                table: "person");

            migrationBuilder.AlterColumn<int>(
                name: "car_id",
                table: "person",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_car_id",
                table: "person",
                column: "car_id",
                principalTable: "car",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_car_id",
                table: "person");

            migrationBuilder.AlterColumn<int>(
                name: "car_id",
                table: "person",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_car_id",
                table: "person",
                column: "car_id",
                principalTable: "car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
