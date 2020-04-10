using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangePhotosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Photos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
