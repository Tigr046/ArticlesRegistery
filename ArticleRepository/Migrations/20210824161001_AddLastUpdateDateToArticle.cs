using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleRepository.Migrations
{
    public partial class AddLastUpdateDateToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Article",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Article");
        }
    }
}
