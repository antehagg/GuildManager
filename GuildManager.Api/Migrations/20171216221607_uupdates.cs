using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class uupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbInventory_DbInventoryId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GameClasses_BaseResources_BaseResourcesId",
                table: "GameClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GameClasses_BaseStats_BaseStatsId",
                table: "GameClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_BaseResources_BaseResourcesId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_GameClasses_ClassId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_DbInventory_InventoryId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_GameClasses_ClassId",
                table: "PlayerCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_DbInventoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DbInventoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DbItem");

            migrationBuilder.RenameTable(
                name: "DbItem",
                newName: "Weapons");

            migrationBuilder.RenameColumn(
                name: "BaseResourcesId",
                table: "Monsters",
                newName: "MonsterBaseResourcesId");

            migrationBuilder.RenameIndex(
                name: "IX_Monsters_BaseResourcesId",
                table: "Monsters",
                newName: "IX_Monsters_MonsterBaseResourcesId");

            migrationBuilder.RenameIndex(
                name: "IX_DbItem_StatsId",
                table: "Weapons",
                newName: "IX_Weapons_StatsId");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "PlayerCharacters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "PlayerCharacters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Monsters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Monsters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BaseStatsId",
                table: "GameClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BaseResourcesId",
                table: "GameClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WeaponType",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeaponEquipType",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SwingSpeed",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinDamage",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxDamage",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipSlotType",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "Weapons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Weapons_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameClasses_BaseResources_BaseResourcesId",
                table: "GameClasses",
                column: "BaseResourcesId",
                principalTable: "BaseResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameClasses_BaseStats_BaseStatsId",
                table: "GameClasses",
                column: "BaseStatsId",
                principalTable: "BaseStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_GameClasses_ClassId",
                table: "Monsters",
                column: "ClassId",
                principalTable: "GameClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_DbInventory_InventoryId",
                table: "Monsters",
                column: "InventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_BaseResources_MonsterBaseResourcesId",
                table: "Monsters",
                column: "MonsterBaseResourcesId",
                principalTable: "BaseResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_GameClasses_ClassId",
                table: "PlayerCharacters",
                column: "ClassId",
                principalTable: "GameClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters",
                column: "InventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_ItemStats_StatsId",
                table: "Weapons",
                column: "StatsId",
                principalTable: "ItemStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Weapons_MainHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GameClasses_BaseResources_BaseResourcesId",
                table: "GameClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GameClasses_BaseStats_BaseStatsId",
                table: "GameClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_GameClasses_ClassId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_DbInventory_InventoryId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_BaseResources_MonsterBaseResourcesId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_GameClasses_ClassId",
                table: "PlayerCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_ItemStats_StatsId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "DbItem");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_StatsId",
                table: "DbItem",
                newName: "IX_DbItem_StatsId");

            migrationBuilder.RenameColumn(
                name: "MonsterBaseResourcesId",
                table: "Monsters",
                newName: "BaseResourcesId");

            migrationBuilder.RenameIndex(
                name: "IX_Monsters_MonsterBaseResourcesId",
                table: "Monsters",
                newName: "IX_Monsters_BaseResourcesId");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponType",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WeaponEquipType",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "SwingSpeed",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "DbItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinDamage",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaxDamage",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EquipSlotType",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DbInventoryId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DbItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "PlayerCharacters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "PlayerCharacters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Monsters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Monsters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseStatsId",
                table: "GameClasses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseResourcesId",
                table: "GameClasses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_DbInventoryId",
                table: "DbItem",
                column: "DbInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DbInventory_DbInventoryId",
                table: "DbItem",
                column: "DbInventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem",
                column: "StatsId",
                principalTable: "ItemStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameClasses_BaseResources_BaseResourcesId",
                table: "GameClasses",
                column: "BaseResourcesId",
                principalTable: "BaseResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameClasses_BaseStats_BaseStatsId",
                table: "GameClasses",
                column: "BaseStatsId",
                principalTable: "BaseStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_BaseResources_BaseResourcesId",
                table: "Monsters",
                column: "BaseResourcesId",
                principalTable: "BaseResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_GameClasses_ClassId",
                table: "Monsters",
                column: "ClassId",
                principalTable: "GameClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_DbInventory_InventoryId",
                table: "Monsters",
                column: "InventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_GameClasses_ClassId",
                table: "PlayerCharacters",
                column: "ClassId",
                principalTable: "GameClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters",
                column: "InventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
