using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTracker_aspNetCoreWebApp_MVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSeen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 1, new DateTime(2021, 10, 24, 19, 34, 9, 769, DateTimeKind.Local).AddTicks(3264), "fi", 6, "Interstella" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 2, new DateTime(2021, 12, 13, 19, 34, 9, 773, DateTimeKind.Local).AddTicks(123), null, 8, "Inception" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 3, null, "action", null, "The dark knight" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
