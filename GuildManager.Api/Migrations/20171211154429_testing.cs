using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildManager.Api.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters");

            migrationBuilder.AlterColumn<int>(
                name: "EquipedItemsId",
                table: "PlayerCharacters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters",
                column: "EquipedItemsId",
                principalTable: "EquippedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters");

            migrationBuilder.AlterColumn<int>(
                name: "EquipedItemsId",
                table: "PlayerCharacters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters",
                column: "EquipedItemsId",
                principalTable: "EquippedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
