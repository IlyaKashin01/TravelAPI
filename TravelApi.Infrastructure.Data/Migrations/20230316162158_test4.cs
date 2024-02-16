using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Infrastructure.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageJoinToGroup_ChatMessages_MessageId",
                table: "MessageJoinToGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageJoinToGroup_Groups_GroupId",
                table: "MessageJoinToGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonJoinToGroups_Groups_GroupId",
                table: "PersonJoinToGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonJoinToGroups_person_PersonId",
                table: "PersonJoinToGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingsJoinToUsers_Settings_SettingsId",
                table: "SettingsJoinToUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                table: "Settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonJoinToGroups",
                table: "PersonJoinToGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageJoinToGroup",
                table: "MessageJoinToGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsJourney",
                table: "EventsJourney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "Settings",
                newName: "settings");

            migrationBuilder.RenameTable(
                name: "PersonJoinToGroups",
                newName: "person_join_to_group");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notification");

            migrationBuilder.RenameTable(
                name: "MessageJoinToGroup",
                newName: "message_join_to_group");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "group_chat_room");

            migrationBuilder.RenameTable(
                name: "EventsJourney",
                newName: "event_journey");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "settings",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "settings",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "NameSetting",
                table: "settings",
                newName: "name_setting");

            migrationBuilder.RenameColumn(
                name: "NameGroup",
                table: "settings",
                newName: "name_group");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "settings",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "settings",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "person_join_to_group",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "person_join_to_group",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "person_join_to_group",
                newName: "group_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "person_join_to_group",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "person_join_to_group",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_PersonJoinToGroups_PersonId",
                table: "person_join_to_group",
                newName: "IX_person_join_to_group_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonJoinToGroups_GroupId",
                table: "person_join_to_group",
                newName: "IX_person_join_to_group_group_id");

            migrationBuilder.RenameColumn(
                name: "Viewed",
                table: "notification",
                newName: "viewed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "notification",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "notification",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "notification",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "notification",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "DateEvent",
                table: "notification",
                newName: "date_event");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "notification",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "message_join_to_group",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "message_join_to_group",
                newName: "message_id");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "message_join_to_group",
                newName: "group_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "message_join_to_group",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "message_join_to_group",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_MessageJoinToGroup_MessageId",
                table: "message_join_to_group",
                newName: "IX_message_join_to_group_message_id");

            migrationBuilder.RenameIndex(
                name: "IX_MessageJoinToGroup_GroupId",
                table: "message_join_to_group",
                newName: "IX_message_join_to_group_group_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "group_chat_room",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "group_chat_room",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "group_chat_room",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "group_chat_room",
                newName: "creator_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "group_chat_room",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "event_journey",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "event_journey",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "event_journey",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "event_journey",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "DateEvent",
                table: "event_journey",
                newName: "date_event");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "event_journey",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "message",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "message",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "message",
                newName: "to_person_id");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "message",
                newName: "sent_at");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "message",
                newName: "from_person_id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "message",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "message",
                newName: "created_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "settings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "settings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "person_join_to_group",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "person_join_to_group",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "notification",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "notification",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "notification",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "message_join_to_group",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "message_join_to_group",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "group_chat_room",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "group_chat_room",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "event_journey",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "event_journey",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "JourneyId",
                table: "event_journey",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "message",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "message",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_settings",
                table: "settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_join_to_group",
                table: "person_join_to_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notification",
                table: "notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message_join_to_group",
                table: "message_join_to_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_group_chat_room",
                table: "group_chat_room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_journey",
                table: "event_journey",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "Id");

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "Id", "delete_date", "name_group", "name_setting", "status" },
                values: new object[,]
                {
                    { 1, null, "Безопасность", "Двухэтапная аутентификация", false },
                    { 2, null, "Конфиденциальность", "Закрытый профиль", false },
                    { 3, null, "Конфиденциальность", "Видимость облачного хранилища", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_notification_PersonId",
                table: "notification",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_event_journey_JourneyId",
                table: "event_journey",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_event_journey_journey_JourneyId",
                table: "event_journey",
                column: "JourneyId",
                principalTable: "journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_join_to_group_group_chat_room_group_id",
                table: "message_join_to_group",
                column: "group_id",
                principalTable: "group_chat_room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_join_to_group_message_message_id",
                table: "message_join_to_group",
                column: "message_id",
                principalTable: "message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notification_person_PersonId",
                table: "notification",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_join_to_group_group_chat_room_group_id",
                table: "person_join_to_group",
                column: "group_id",
                principalTable: "group_chat_room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_join_to_group_person_person_id",
                table: "person_join_to_group",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsJoinToUsers_settings_SettingsId",
                table: "SettingsJoinToUsers",
                column: "SettingsId",
                principalTable: "settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_journey_journey_JourneyId",
                table: "event_journey");

            migrationBuilder.DropForeignKey(
                name: "FK_message_join_to_group_group_chat_room_group_id",
                table: "message_join_to_group");

            migrationBuilder.DropForeignKey(
                name: "FK_message_join_to_group_message_message_id",
                table: "message_join_to_group");

            migrationBuilder.DropForeignKey(
                name: "FK_notification_person_PersonId",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "FK_person_join_to_group_group_chat_room_group_id",
                table: "person_join_to_group");

            migrationBuilder.DropForeignKey(
                name: "FK_person_join_to_group_person_person_id",
                table: "person_join_to_group");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingsJoinToUsers_settings_SettingsId",
                table: "SettingsJoinToUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_settings",
                table: "settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_join_to_group",
                table: "person_join_to_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notification",
                table: "notification");

            migrationBuilder.DropIndex(
                name: "IX_notification_PersonId",
                table: "notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message_join_to_group",
                table: "message_join_to_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_group_chat_room",
                table: "group_chat_room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_journey",
                table: "event_journey");

            migrationBuilder.DropIndex(
                name: "IX_event_journey_JourneyId",
                table: "event_journey");

            migrationBuilder.DeleteData(
                table: "settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "notification");

            migrationBuilder.DropColumn(
                name: "JourneyId",
                table: "event_journey");

            migrationBuilder.RenameTable(
                name: "settings",
                newName: "Settings");

            migrationBuilder.RenameTable(
                name: "person_join_to_group",
                newName: "PersonJoinToGroups");

            migrationBuilder.RenameTable(
                name: "notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "message_join_to_group",
                newName: "MessageJoinToGroup");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "group_chat_room",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "event_journey",
                newName: "EventsJourney");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Settings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Settings",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "name_setting",
                table: "Settings",
                newName: "NameSetting");

            migrationBuilder.RenameColumn(
                name: "name_group",
                table: "Settings",
                newName: "NameGroup");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Settings",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Settings",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "PersonJoinToGroups",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "PersonJoinToGroups",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "group_id",
                table: "PersonJoinToGroups",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "PersonJoinToGroups",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "PersonJoinToGroups",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_person_join_to_group_person_id",
                table: "PersonJoinToGroups",
                newName: "IX_PersonJoinToGroups_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_person_join_to_group_group_id",
                table: "PersonJoinToGroups",
                newName: "IX_PersonJoinToGroups_GroupId");

            migrationBuilder.RenameColumn(
                name: "viewed",
                table: "Notifications",
                newName: "Viewed");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Notifications",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Notifications",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Notifications",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Notifications",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "date_event",
                table: "Notifications",
                newName: "DateEvent");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Notifications",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "MessageJoinToGroup",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "message_id",
                table: "MessageJoinToGroup",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "group_id",
                table: "MessageJoinToGroup",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "MessageJoinToGroup",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "MessageJoinToGroup",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_message_join_to_group_message_id",
                table: "MessageJoinToGroup",
                newName: "IX_MessageJoinToGroup_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_message_join_to_group_group_id",
                table: "MessageJoinToGroup",
                newName: "IX_MessageJoinToGroup_GroupId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "ChatMessages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "ChatMessages",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "to_person_id",
                table: "ChatMessages",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "sent_at",
                table: "ChatMessages",
                newName: "SentAt");

            migrationBuilder.RenameColumn(
                name: "from_person_id",
                table: "ChatMessages",
                newName: "FromUserId");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "ChatMessages",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "ChatMessages",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Groups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Groups",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Groups",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "creator_id",
                table: "Groups",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Groups",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "EventsJourney",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "EventsJourney",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "EventsJourney",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "EventsJourney",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "date_event",
                table: "EventsJourney",
                newName: "DateEvent");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "EventsJourney",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Settings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonJoinToGroups",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonJoinToGroups",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "MessageJoinToGroup",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MessageJoinToGroup",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ChatMessages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ChatMessages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EventsJourney",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventsJourney",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                table: "Settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonJoinToGroups",
                table: "PersonJoinToGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageJoinToGroup",
                table: "MessageJoinToGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsJourney",
                table: "EventsJourney",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageJoinToGroup_ChatMessages_MessageId",
                table: "MessageJoinToGroup",
                column: "MessageId",
                principalTable: "ChatMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageJoinToGroup_Groups_GroupId",
                table: "MessageJoinToGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonJoinToGroups_Groups_GroupId",
                table: "PersonJoinToGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonJoinToGroups_person_PersonId",
                table: "PersonJoinToGroups",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsJoinToUsers_Settings_SettingsId",
                table: "SettingsJoinToUsers",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
