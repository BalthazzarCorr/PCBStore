using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PCBStore.Data.Migrations
{
    public partial class tableCommetsToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commets_AspNetUsers_AuthorId",
                table: "Commets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commets",
                table: "Commets");

            migrationBuilder.RenameTable(
                name: "Commets",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Commets_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Commets");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Commets",
                newName: "IX_Commets_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commets",
                table: "Commets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commets_AspNetUsers_AuthorId",
                table: "Commets",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
