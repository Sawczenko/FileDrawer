using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorage.Migrations
{
    public partial class EntitiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                schema: "Files",
                table: "Files",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "Drawers",
                table: "Drawers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FileCount",
                schema: "Drawers",
                table: "Drawers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                schema: "Files",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "Drawers",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "FileCount",
                schema: "Drawers",
                table: "Drawers");
        }
    }
}
