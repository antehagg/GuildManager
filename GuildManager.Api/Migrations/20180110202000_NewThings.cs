using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GuildManager.Api.Migrations
{
    public partial class NewThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_ArmId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_ChestId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_FeetId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_HandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_HeadId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_LegId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Weapons_MainHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_NeckId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Weapons_OffHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_RinegOneId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_RingTwoId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_Armor_WaistId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_ItemStats_StatsId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "DbItem");

            migrationBuilder.RenameColumn(
                name: "EquipSlotType",
                table: "DbItem",
                newName: "DbArmor_EquipSlotType");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_StatsId",
                table: "DbItem",
                newName: "IX_DbItem_StatsId");

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
                name: "DbArmor_EquipSlotType",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DbItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EquipSlotType",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmorType",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DbSpawnId",
                table: "Monsters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DbSpawnId1",
                table: "Monsters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DbItemId",
                table: "GameClasses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PossibleLoot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chance = table.Column<double>(nullable: false),
                    DbMonsterId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleLoot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PossibleLoot_Monsters_DbMonsterId",
                        column: x => x.DbMonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PossibleLoot_DbItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "DbItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CastTime = table.Column<int>(nullable: false),
                    Cooldown = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    DbGameClassId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_GameClasses_DbGameClassId",
                        column: x => x.DbGameClassId,
                        principalTable: "GameClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ZoneType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: true),
                    TargetType = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effect_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbSpawn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DbZoneId = table.Column<int>(nullable: true),
                    SpawnAmount = table.Column<int>(nullable: false),
                    SpawnNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSpawn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSpawn_Zones_DbZoneId",
                        column: x => x.DbZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_DbSpawnId",
                table: "Monsters",
                column: "DbSpawnId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_DbSpawnId1",
                table: "Monsters",
                column: "DbSpawnId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameClasses_DbItemId",
                table: "GameClasses",
                column: "DbItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSpawn_DbZoneId",
                table: "DbSpawn",
                column: "DbZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Effect_SkillId",
                table: "Effect",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleLoot_DbMonsterId",
                table: "PossibleLoot",
                column: "DbMonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleLoot_ItemId",
                table: "PossibleLoot",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DbGameClassId",
                table: "Skills",
                column: "DbGameClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem",
                column: "StatsId",
                principalTable: "ItemStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_ArmId",
                table: "EquippedItems",
                column: "ArmId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_ChestId",
                table: "EquippedItems",
                column: "ChestId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_FeetId",
                table: "EquippedItems",
                column: "FeetId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_HandId",
                table: "EquippedItems",
                column: "HandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_HeadId",
                table: "EquippedItems",
                column: "HeadId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_LegId",
                table: "EquippedItems",
                column: "LegId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_NeckId",
                table: "EquippedItems",
                column: "NeckId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_OffHandId",
                table: "EquippedItems",
                column: "OffHandId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_RinegOneId",
                table: "EquippedItems",
                column: "RinegOneId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_RingTwoId",
                table: "EquippedItems",
                column: "RingTwoId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_DbItem_WaistId",
                table: "EquippedItems",
                column: "WaistId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameClasses_DbItem_DbItemId",
                table: "GameClasses",
                column: "DbItemId",
                principalTable: "DbItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_DbSpawn_DbSpawnId",
                table: "Monsters",
                column: "DbSpawnId",
                principalTable: "DbSpawn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_DbSpawn_DbSpawnId1",
                table: "Monsters",
                column: "DbSpawnId1",
                principalTable: "DbSpawn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_ArmId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_ChestId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_FeetId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_HandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_HeadId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_LegId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_MainHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_NeckId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_OffHandId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_RinegOneId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_RingTwoId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquippedItems_DbItem_WaistId",
                table: "EquippedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GameClasses_DbItem_DbItemId",
                table: "GameClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_DbSpawn_DbSpawnId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_DbSpawn_DbSpawnId1",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "DbSpawn");

            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "PossibleLoot");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_DbSpawnId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_DbSpawnId1",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_GameClasses_DbItemId",
                table: "GameClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DbSpawnId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DbSpawnId1",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DbItemId",
                table: "GameClasses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "EquipSlotType",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ArmorType",
                table: "DbItem");

            migrationBuilder.RenameTable(
                name: "DbItem",
                newName: "Weapons");

            migrationBuilder.RenameColumn(
                name: "DbArmor_EquipSlotType",
                table: "Weapons",
                newName: "EquipSlotType");

            migrationBuilder.RenameIndex(
                name: "IX_DbItem_StatsId",
                table: "Weapons",
                newName: "IX_Weapons_StatsId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipSlotType",
                table: "Weapons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArmorType = table.Column<int>(nullable: false),
                    EquipSlotType = table.Column<int>(nullable: false),
                    ItemRarity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StatsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armor_ItemStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "ItemStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armor_StatsId",
                table: "Armor",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_ArmId",
                table: "EquippedItems",
                column: "ArmId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_ChestId",
                table: "EquippedItems",
                column: "ChestId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_FeetId",
                table: "EquippedItems",
                column: "FeetId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_HandId",
                table: "EquippedItems",
                column: "HandId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_HeadId",
                table: "EquippedItems",
                column: "HeadId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_LegId",
                table: "EquippedItems",
                column: "LegId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Weapons_MainHandId",
                table: "EquippedItems",
                column: "MainHandId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_NeckId",
                table: "EquippedItems",
                column: "NeckId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Weapons_OffHandId",
                table: "EquippedItems",
                column: "OffHandId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_RinegOneId",
                table: "EquippedItems",
                column: "RinegOneId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_RingTwoId",
                table: "EquippedItems",
                column: "RingTwoId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquippedItems_Armor_WaistId",
                table: "EquippedItems",
                column: "WaistId",
                principalTable: "Armor",
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
    }
}
