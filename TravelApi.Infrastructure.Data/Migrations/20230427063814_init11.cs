using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "image");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "image",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "data",
                table: "image",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "storage_id",
                table: "image",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_image_PersonId",
                table: "image",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_storage_id",
                table: "image",
                column: "storage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_person_PersonId",
                table: "image",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_image_storage_storage_id",
                table: "image",
                column: "storage_id",
                principalTable: "storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_person_PersonId",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_storage_storage_id",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_PersonId",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_storage_id",
                table: "image");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "image");

            migrationBuilder.DropColumn(
                name: "data",
                table: "image");

            migrationBuilder.DropColumn(
                name: "storage_id",
                table: "image");

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "image",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
