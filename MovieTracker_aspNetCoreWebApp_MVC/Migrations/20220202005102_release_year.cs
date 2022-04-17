using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTracker_aspNetCoreWebApp_MVC.Migrations
{
    public partial class release_year : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSeen",
                value: new DateTime(2021, 10, 24, 19, 51, 2, 411, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSeen",
                value: new DateTime(2021, 12, 13, 19, 51, 2, 414, DateTimeKind.Local).AddTicks(4090));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSeen",
                value: new DateTime(2021, 10, 24, 19, 34, 9, 769, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSeen",
                value: new DateTime(2021, 12, 13, 19, 34, 9, 773, DateTimeKind.Local).AddTicks(123));
        }
    }
}
