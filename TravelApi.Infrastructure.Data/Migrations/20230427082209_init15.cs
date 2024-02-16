using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "person",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_ImageId",
                table: "person",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_person_image_ImageId",
                table: "person",
                column: "ImageId",
                principalTable: "image",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_image_ImageId",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_ImageId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "person");
        }
    }
}
