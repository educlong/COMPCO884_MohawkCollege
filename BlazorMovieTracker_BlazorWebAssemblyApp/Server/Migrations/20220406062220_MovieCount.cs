using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovieTracker_BlazorWebAssemblyApp.Server.Migrations
{
    public partial class MovieCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieCount",
                table: "Genre",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieCount",
                table: "Genre");
        }
    }
}
