using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_journey_category_category_id",
                table: "journey");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropIndex(
                name: "IX_journey_category_id",
                table: "journey");

            migrationBuilder.DropColumn(
                name: "cost",
                table: "service");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "journey",
                newName: "projected_cost");

            migrationBuilder.AddColumn<decimal>(
                name: "actual_cost",
                table: "service",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "expected_cost",
                table: "service",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "projected_cost",
                table: "service",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "actual_cost",
                table: "journey",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "expected_cost",
                table: "journey",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    expenditure = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_CarId",
                table: "person",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_car_CarId",
                table: "person",
                column: "CarId",
                principalTable: "car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_car_CarId",
                table: "person");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropIndex(
                name: "IX_person_CarId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "actual_cost",
                table: "service");

            migrationBuilder.DropColumn(
                name: "expected_cost",
                table: "service");

            migrationBuilder.DropColumn(
                name: "projected_cost",
                table: "service");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "actual_cost",
                table: "journey");

            migrationBuilder.DropColumn(
                name: "expected_cost",
                table: "journey");

            migrationBuilder.RenameColumn(
                name: "projected_cost",
                table: "journey",
                newName: "balance");

            migrationBuilder.AddColumn<double>(
                name: "cost",
                table: "service",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_journey_category_id",
                table: "journey",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_journey_category_category_id",
                table: "journey",
                column: "category_id",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
