using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleRepository.Migrations
{
    public partial class AddCreationDateToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
