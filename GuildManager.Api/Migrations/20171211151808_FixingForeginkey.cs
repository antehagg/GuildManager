using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildManager.Api.Migrations
{
    public partial class FixingForeginkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems");

            migrationBuilder.AlterColumn<int>(
                name: "MainHandId",
                table: "EquippedItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems");

            migrationBuilder.AlterColumn<int>(
                name: "MainHandId",
                table: "EquippedItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
