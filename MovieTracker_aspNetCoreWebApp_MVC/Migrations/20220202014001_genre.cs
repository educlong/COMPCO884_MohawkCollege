using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTracker_aspNetCoreWebApp_MVC.Migrations
{
    public partial class genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreDescription = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreDescription" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 23, "War" },
                    { 22, "Thriller" },
                    { 21, "Superhero" },
                    { 20, "Sport" },
                    { 19, "Short Film" },
                    { 18, "Sci-Fi" },
                    { 17, "Romance" },
                    { 16, "Mystery" },
                    { 15, "Musical" },
                    { 14, "Music" },
                    { 24, "Western" },
                    { 13, "Horror" },
                    { 11, "Film Noir" },
                    { 10, "Fantasy" },
                    { 9, "Family" },
                    { 8, "Drama" },
                    { 7, "Documentary" },
                    { 6, "Crime" },
                    { 5, "Comedy" },
                    { 4, "Biography" },
                    { 3, "Animation" },
                    { 2, "Adventure" },
                    { 12, "History" }
                });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSeen",
                value: new DateTime(2021, 12, 13, 20, 40, 0, 604, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSeen", "GenreId" },
                values: new object[] { new DateTime(2021, 10, 24, 20, 40, 0, 600, DateTimeKind.Local).AddTicks(8577), 18 });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenreId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genres_GenreId",
                table: "Movie",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_GenreId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movie_GenreId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSeen", "Genre" },
                values: new object[] { new DateTime(2021, 10, 24, 19, 51, 2, 411, DateTimeKind.Local).AddTicks(6790), "fi" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSeen",
                value: new DateTime(2021, 12, 13, 19, 51, 2, 414, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "Genre",
                value: "action");
        }
    }
}
