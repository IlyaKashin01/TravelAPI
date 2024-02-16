using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_storage_storage_id",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_person_storage_storage_id",
                table: "person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_storage",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "file_name",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "file_path",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "file_type",
                table: "storage");

            migrationBuilder.RenameTable(
                name: "storage",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Storage",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Storage",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Storage",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Storage",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Storage",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "person_file",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_type = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    StrorageId = table.Column<int>(type: "integer", nullable: false),
                    StorageId = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_file", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_file_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_file_StorageId",
                table: "person_file",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_image_Storage_storage_id",
                table: "image",
                column: "storage_id",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_Storage_storage_id",
                table: "person",
                column: "storage_id",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_Storage_storage_id",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_person_Storage_storage_id",
                table: "person");

            migrationBuilder.DropTable(
                name: "person_file");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "storage");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "storage",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "storage",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "storage",
                newName: "created_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "storage",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "storage",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "file_name",
                table: "storage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "storage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "file_type",
                table: "storage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_storage",
                table: "storage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_storage_storage_id",
                table: "image",
                column: "storage_id",
                principalTable: "storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_storage_storage_id",
                table: "person",
                column: "storage_id",
                principalTable: "storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
