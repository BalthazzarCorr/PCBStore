using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PCBStore.Data.Migrations
{
    public partial class deletingArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsArticles_AspNetUsers_AuthorId",
                table: "NewsArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsArticles_AspNetUsers_AuthorId",
                table: "NewsArticles",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsArticles_AspNetUsers_AuthorId",
                table: "NewsArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsArticles_AspNetUsers_AuthorId",
                table: "NewsArticles",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
