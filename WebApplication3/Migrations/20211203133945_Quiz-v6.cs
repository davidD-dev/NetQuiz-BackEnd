using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Quizv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Quiz",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Question",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Answer",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quiz",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Question",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Question",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Answer",
                newName: "id");
        }
    }
}
