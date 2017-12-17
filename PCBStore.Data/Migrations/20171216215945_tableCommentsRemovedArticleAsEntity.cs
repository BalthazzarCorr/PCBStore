using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PCBStore.Data.Migrations
{
    public partial class tableCommentsRemovedArticleAsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commets_NewsArticles_NewsArticleId",
                table: "Commets");

            migrationBuilder.DropIndex(
                name: "IX_Commets_NewsArticleId",
                table: "Commets");

            migrationBuilder.DropColumn(
                name: "NewsArticleId",
                table: "Commets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsArticleId",
                table: "Commets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commets_NewsArticleId",
                table: "Commets",
                column: "NewsArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commets_NewsArticles_NewsArticleId",
                table: "Commets",
                column: "NewsArticleId",
                principalTable: "NewsArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
