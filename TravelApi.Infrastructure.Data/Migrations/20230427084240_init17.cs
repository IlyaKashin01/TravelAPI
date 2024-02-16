using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_person_PersonId",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_PersonId",
                table: "image");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "image");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "person",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "person");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_PersonId",
                table: "image",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_image_person_PersonId",
                table: "image",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id");
        }
    }
}
