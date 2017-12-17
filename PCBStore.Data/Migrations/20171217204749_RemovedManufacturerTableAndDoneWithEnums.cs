using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PCBStore.Data.Migrations
{
    public partial class RemovedManufacturerTableAndDoneWithEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Manufacturer_ManufacturerId",
                table: "Components");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Components_ManufacturerId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "Manufacturer",
                table: "Components",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Components",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ManufacturerId",
                table: "Components",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Manufacturer_ManufacturerId",
                table: "Components",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
