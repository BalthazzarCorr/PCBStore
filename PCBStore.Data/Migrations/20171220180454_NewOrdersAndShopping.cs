using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PCBStore.Data.Migrations
{
    public partial class NewOrdersAndShopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderComponents_Orders_ComponentId",
                table: "OrderComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderComponents",
                table: "OrderComponents");

            migrationBuilder.DropColumn(
                name: "Schematic",
                table: "OrderComponents");

            migrationBuilder.AddColumn<byte[]>(
                name: "Schematic",
                table: "Orders",
                maxLength: 20971520,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderComponents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "ComponentPrice",
                table: "OrderComponents",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderComponents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderComponents",
                table: "OrderComponents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComponents_OrderId",
                table: "OrderComponents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderComponents_Orders_OrderId",
                table: "OrderComponents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderComponents_Orders_OrderId",
                table: "OrderComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderComponents",
                table: "OrderComponents");

            migrationBuilder.DropIndex(
                name: "IX_OrderComponents_OrderId",
                table: "OrderComponents");

            migrationBuilder.DropColumn(
                name: "Schematic",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderComponents");

            migrationBuilder.DropColumn(
                name: "ComponentPrice",
                table: "OrderComponents");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderComponents");

            migrationBuilder.AddColumn<byte[]>(
                name: "Schematic",
                table: "OrderComponents",
                maxLength: 20971520,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderComponents",
                table: "OrderComponents",
                columns: new[] { "OrderId", "ComponentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderComponents_Orders_ComponentId",
                table: "OrderComponents",
                column: "ComponentId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
