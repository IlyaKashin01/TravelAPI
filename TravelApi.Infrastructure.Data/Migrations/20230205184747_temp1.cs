using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class temp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Journeys_JourneyId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_People_PersonId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_People_PersonId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_JourneyJoinToPeople_Journeys_JourneyId",
                table: "JourneyJoinToPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_JourneyJoinToPeople_People_PersonId",
                table: "JourneyJoinToPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Categories_CategoryId",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_People_PersonId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Journeys_JourneyId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journeys",
                table: "Journeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JourneyJoinToPeople",
                table: "JourneyJoinToPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Coordinates",
                newName: "coordinates");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "service");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "post");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "person");

            migrationBuilder.RenameTable(
                name: "Journeys",
                newName: "journey");

            migrationBuilder.RenameTable(
                name: "JourneyJoinToPeople",
                newName: "journey_join_to_person");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "image");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "friend");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "coordinates",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitube",
                table: "coordinates",
                newName: "latitube");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "coordinates",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "coordinates",
                newName: "journey_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "coordinates",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "coordinates",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinates_PersonId",
                table: "coordinates",
                newName: "IX_coordinates_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinates_JourneyId",
                table: "coordinates",
                newName: "IX_coordinates_journey_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "service",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "service",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "service",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "service",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "service",
                newName: "journey_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "service",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "service",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Services_JourneyId",
                table: "service",
                newName: "IX_service_journey_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "post",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "post",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "post",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "post",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "post",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "post",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CountShare",
                table: "post",
                newName: "count_share");

            migrationBuilder.RenameColumn(
                name: "CountLike",
                table: "post",
                newName: "count_like");

            migrationBuilder.RenameColumn(
                name: "CountDisLike",
                table: "post",
                newName: "count_dis_like");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PersonId",
                table: "post",
                newName: "IX_post_person_id");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "person",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "person",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "person",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "person",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "VerifiedEmail",
                table: "person",
                newName: "verified_email");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "person",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "person",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "person",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "person",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IsVerifiedEmail",
                table: "person",
                newName: "is_verified_email");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "person",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "person",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "person",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "journey",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "journey",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "journey",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "journey",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "journey",
                newName: "date_start");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "journey",
                newName: "date_end");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "journey",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "journey",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Journeys_CategoryId",
                table: "journey",
                newName: "IX_journey_category_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "journey_join_to_person",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "journey_join_to_person",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "journey_join_to_person",
                newName: "journey_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "journey_join_to_person",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "journey_join_to_person",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_JourneyJoinToPeople_PersonId",
                table: "journey_join_to_person",
                newName: "IX_journey_join_to_person_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_JourneyJoinToPeople_JourneyId",
                table: "journey_join_to_person",
                newName: "IX_journey_join_to_person_journey_id");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "image",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "image",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "image",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "image",
                newName: "post_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "image",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "image",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PostId",
                table: "image",
                newName: "IX_image_post_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "friend",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "friend",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PersonTwo",
                table: "friend",
                newName: "person_two");

            migrationBuilder.RenameColumn(
                name: "PersonOne",
                table: "friend",
                newName: "person_one");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "friend",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "friend",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "friend",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_PersonId",
                table: "friend",
                newName: "IX_friend_person_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "category",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "category",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "category",
                newName: "created_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "coordinates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "coordinates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "name_place",
                table: "coordinates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "route_id",
                table: "coordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "service",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "service",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "person",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "person",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "storage_id",
                table: "person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "journey",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "journey",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "journey",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "journey_join_to_person",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "journey_join_to_person",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "image",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "image",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "friend",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "friend",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_coordinates",
                table: "coordinates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service",
                table: "service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                table: "post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person",
                table: "person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_journey",
                table: "journey",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_journey_join_to_person",
                table: "journey_join_to_person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_image",
                table: "image",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_friend",
                table: "friend",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "storage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_type = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<string>(type: "text", nullable: false),
                    journey_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_task_journey_journey_id",
                        column: x => x.journey_id,
                        principalTable: "journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coordinates_route_id",
                table: "coordinates",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_storage_id",
                table: "person",
                column: "storage_id");

            migrationBuilder.CreateIndex(
                name: "IX_task_journey_id",
                table: "task",
                column: "journey_id");

            migrationBuilder.AddForeignKey(
                name: "FK_coordinates_journey_journey_id",
                table: "coordinates",
                column: "journey_id",
                principalTable: "journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_coordinates_person_PersonId",
                table: "coordinates",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_coordinates_route_route_id",
                table: "coordinates",
                column: "route_id",
                principalTable: "route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_friend_person_person_id",
                table: "friend",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_image_post_post_id",
                table: "image",
                column: "post_id",
                principalTable: "post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journey_category_category_id",
                table: "journey",
                column: "category_id",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journey_join_to_person_journey_journey_id",
                table: "journey_join_to_person",
                column: "journey_id",
                principalTable: "journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journey_join_to_person_person_person_id",
                table: "journey_join_to_person",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_storage_storage_id",
                table: "person",
                column: "storage_id",
                principalTable: "storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_person_person_id",
                table: "post",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_journey_journey_id",
                table: "service",
                column: "journey_id",
                principalTable: "journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coordinates_journey_journey_id",
                table: "coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_coordinates_person_PersonId",
                table: "coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_coordinates_route_route_id",
                table: "coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_friend_person_person_id",
                table: "friend");

            migrationBuilder.DropForeignKey(
                name: "FK_image_post_post_id",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_journey_category_category_id",
                table: "journey");

            migrationBuilder.DropForeignKey(
                name: "FK_journey_join_to_person_journey_journey_id",
                table: "journey_join_to_person");

            migrationBuilder.DropForeignKey(
                name: "FK_journey_join_to_person_person_person_id",
                table: "journey_join_to_person");

            migrationBuilder.DropForeignKey(
                name: "FK_person_storage_storage_id",
                table: "person");

            migrationBuilder.DropForeignKey(
                name: "FK_post_person_person_id",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_service_journey_journey_id",
                table: "service");

            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "storage");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_coordinates",
                table: "coordinates");

            migrationBuilder.DropIndex(
                name: "IX_coordinates_route_id",
                table: "coordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service",
                table: "service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_storage_id",
                table: "person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_journey_join_to_person",
                table: "journey_join_to_person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_journey",
                table: "journey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_image",
                table: "image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_friend",
                table: "friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropColumn(
                name: "name_place",
                table: "coordinates");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "coordinates");

            migrationBuilder.DropColumn(
                name: "storage_id",
                table: "person");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "journey");

            migrationBuilder.RenameTable(
                name: "coordinates",
                newName: "Coordinates");

            migrationBuilder.RenameTable(
                name: "service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "journey_join_to_person",
                newName: "JourneyJoinToPeople");

            migrationBuilder.RenameTable(
                name: "journey",
                newName: "Journeys");

            migrationBuilder.RenameTable(
                name: "image",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "friend",
                newName: "Friends");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Coordinates",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitube",
                table: "Coordinates",
                newName: "Latitube");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Coordinates",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "journey_id",
                table: "Coordinates",
                newName: "JourneyId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Coordinates",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Coordinates",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_coordinates_PersonId",
                table: "Coordinates",
                newName: "IX_Coordinates_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_coordinates_journey_id",
                table: "Coordinates",
                newName: "IX_Coordinates_JourneyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Services",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Services",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Services",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Services",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "journey_id",
                table: "Services",
                newName: "JourneyId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Services",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Services",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_service_journey_id",
                table: "Services",
                newName: "IX_Services_JourneyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Posts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Posts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Posts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Posts",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Posts",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Posts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "count_share",
                table: "Posts",
                newName: "CountShare");

            migrationBuilder.RenameColumn(
                name: "count_like",
                table: "Posts",
                newName: "CountLike");

            migrationBuilder.RenameColumn(
                name: "count_dis_like",
                table: "Posts",
                newName: "CountDisLike");

            migrationBuilder.RenameIndex(
                name: "IX_post_person_id",
                table: "Posts",
                newName: "IX_Posts_PersonId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "People",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "People",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "People",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "People",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "verified_email",
                table: "People",
                newName: "VerifiedEmail");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "People",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "People",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "People",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "People",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_verified_email",
                table: "People",
                newName: "IsVerifiedEmail");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "People",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "People",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "People",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "JourneyJoinToPeople",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "JourneyJoinToPeople",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "journey_id",
                table: "JourneyJoinToPeople",
                newName: "JourneyId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "JourneyJoinToPeople",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "JourneyJoinToPeople",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_journey_join_to_person_person_id",
                table: "JourneyJoinToPeople",
                newName: "IX_JourneyJoinToPeople_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_journey_join_to_person_journey_id",
                table: "JourneyJoinToPeople",
                newName: "IX_JourneyJoinToPeople_JourneyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Journeys",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Journeys",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Journeys",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Journeys",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "date_start",
                table: "Journeys",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "date_end",
                table: "Journeys",
                newName: "DateEnd");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Journeys",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Journeys",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_journey_category_id",
                table: "Journeys",
                newName: "IX_Journeys_CategoryId");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "Images",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Images",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "post_id",
                table: "Images",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Images",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Images",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_image_post_id",
                table: "Images",
                newName: "IX_Images_PostId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Friends",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Friends",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "person_two",
                table: "Friends",
                newName: "PersonTwo");

            migrationBuilder.RenameColumn(
                name: "person_one",
                table: "Friends",
                newName: "PersonOne");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Friends",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Friends",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Friends",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_friend_person_id",
                table: "Friends",
                newName: "IX_Friends_PersonId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Categories",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Categories",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Coordinates",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Coordinates",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Services",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Services",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Posts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "People",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "People",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "JourneyJoinToPeople",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "JourneyJoinToPeople",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Journeys",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Journeys",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Images",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Friends",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Friends",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JourneyJoinToPeople",
                table: "JourneyJoinToPeople",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journeys",
                table: "Journeys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Journeys_JourneyId",
                table: "Coordinates",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_People_PersonId",
                table: "Coordinates",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_People_PersonId",
                table: "Friends",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyJoinToPeople_Journeys_JourneyId",
                table: "JourneyJoinToPeople",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyJoinToPeople_People_PersonId",
                table: "JourneyJoinToPeople",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Categories_CategoryId",
                table: "Journeys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_People_PersonId",
                table: "Posts",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Journeys_JourneyId",
                table: "Services",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
