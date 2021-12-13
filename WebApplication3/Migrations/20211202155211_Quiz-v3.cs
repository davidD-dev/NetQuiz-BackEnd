using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Quizv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_questionid",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_quizid",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "quizid",
                table: "Question",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_quizid",
                table: "Question",
                newName: "IX_Question_QuizId");

            migrationBuilder.RenameColumn(
                name: "questionid",
                table: "Answer",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_questionid",
                table: "Answer",
                newName: "IX_Answer_QuestionId");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuizId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "Answer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Question",
                newName: "quizid");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                newName: "IX_Question_quizid");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answer",
                newName: "questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                newName: "IX_Answer_questionid");

            migrationBuilder.AlterColumn<Guid>(
                name: "quizid",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "questionid",
                table: "Answer",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_questionid",
                table: "Answer",
                column: "questionid",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_quizid",
                table: "Question",
                column: "quizid",
                principalTable: "Quiz",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
