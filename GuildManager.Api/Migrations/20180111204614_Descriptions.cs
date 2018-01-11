using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildManager.Api.Migrations
{
    public partial class Descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_RinegOneId",
                table: "EquippedItems");

            migrationBuilder.RenameColumn(
                name: "RinegOneId",
                table: "EquippedItems",
                newName: "RingOneId");

            migrationBuilder.RenameIndex(
                name: "IX_EquippedItems_RinegOneId",
                table: "EquippedItems",
                newName: "IX_EquippedItems_RingOneId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GameClasses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Effect",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Effect",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_RingOneId",
                table: "EquippedItems",
                column: "RingOneId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_RingOneId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GameClasses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Effect");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Effect");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DbItem");

            migrationBuilder.RenameColumn(
                name: "RingOneId",
                table: "EquippedItems",
                newName: "RinegOneId");

            migrationBuilder.RenameIndex(
                name: "IX_EquippedItems_RingOneId",
                table: "EquippedItems",
                newName: "IX_EquippedItems_RinegOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_RinegOneId",
                table: "EquippedItems",
                column: "RinegOneId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
