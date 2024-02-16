using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JourneyPerson");

            migrationBuilder.RenameColumn(
                name: "Verified",
                table: "People",
                newName: "VerifiedEmail");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "People",
                newName: "IsVerifiedEmail");

            migrationBuilder.CreateTable(
                name: "JourneyJoinToPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JourneyId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyJoinToPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JourneyJoinToPeople_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyJoinToPeople_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JourneyJoinToPeople_JourneyId",
                table: "JourneyJoinToPeople",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyJoinToPeople_PersonId",
                table: "JourneyJoinToPeople",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JourneyJoinToPeople");

            migrationBuilder.RenameColumn(
                name: "VerifiedEmail",
                table: "People",
                newName: "Verified");

            migrationBuilder.RenameColumn(
                name: "IsVerifiedEmail",
                table: "People",
                newName: "IsVerified");

            migrationBuilder.CreateTable(
                name: "JourneyPerson",
                columns: table => new
                {
                    JourneyId = table.Column<int>(type: "integer", nullable: false),
                    PeopleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyPerson", x => new { x.JourneyId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_JourneyPerson_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JourneyPerson_PeopleId",
                table: "JourneyPerson",
                column: "PeopleId");
        }
    }
}
