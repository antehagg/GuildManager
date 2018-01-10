using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class EquippedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbEquipedItems_DbItem_MainHandId",
                table: "DbEquipedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbEquipedItems_EquipedItemsId",
                table: "PlayerCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbEquipedItems",
                table: "DbEquipedItems");

            migrationBuilder.RenameTable(
                name: "DbEquipedItems",
                newName: "EquippedItems");

            migrationBuilder.RenameIndex(
                name: "IX_DbEquipedItems_MainHandId",
                table: "EquippedItems",
                newName: "IX_EquippedItems_MainHandId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipedItemsId",
                table: "PlayerCharacters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainHandId",
                table: "EquippedItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquippedItems",
                table: "EquippedItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters",
                column: "EquipedItemsId",
                principalTable: "EquippedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_EquippedItems_EquipedItemsId",
                table: "PlayerCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquippedItems",
                table: "EquippedItems");

            migrationBuilder.RenameTable(
                name: "EquippedItems",
                newName: "DbEquipedItems");

            migrationBuilder.RenameIndex(
                name: "IX_EquippedItems_MainHandId",
                table: "DbEquipedItems",
                newName: "IX_DbEquipedItems_MainHandId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipedItemsId",
                table: "PlayerCharacters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MainHandId",
                table: "DbEquipedItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbEquipedItems",
                table: "DbEquipedItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbEquipedItems_DbItem_MainHandId",
                table: "DbEquipedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_DbEquipedItems_EquipedItemsId",
                table: "PlayerCharacters",
                column: "EquipedItemsId",
                principalTable: "DbEquipedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
