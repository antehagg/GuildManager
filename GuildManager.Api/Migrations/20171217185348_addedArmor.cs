using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class addedArmor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "ItemStats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArmId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChestId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeetId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HandId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LegId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeckId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffHandId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RinegOneId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RingTwoId",
                table: "EquippedItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaistId",
                table: "EquippedItems",
                nullable: true);

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
                name: "IX_EquippedItems_ArmId",
                table: "EquippedItems",
                column: "ArmId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_ChestId",
                table: "EquippedItems",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_FeetId",
                table: "EquippedItems",
                column: "FeetId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_HandId",
                table: "EquippedItems",
                column: "HandId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_HeadId",
                table: "EquippedItems",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_LegId",
                table: "EquippedItems",
                column: "LegId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_NeckId",
                table: "EquippedItems",
                column: "NeckId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_OffHandId",
                table: "EquippedItems",
                column: "OffHandId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_RinegOneId",
                table: "EquippedItems",
                column: "RinegOneId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_RingTwoId",
                table: "EquippedItems",
                column: "RingTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquippedItems_WaistId",
                table: "EquippedItems",
                column: "WaistId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_ArmId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_ChestId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_FeetId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_HandId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_HeadId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_LegId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_NeckId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_OffHandId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_RinegOneId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_RingTwoId",
                table: "EquippedItems");

            migrationBuilder.DropIndex(
                name: "IX_EquippedItems_WaistId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "Armor",
                table: "ItemStats");

            migrationBuilder.DropColumn(
                name: "ArmId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "ChestId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "FeetId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "HandId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "LegId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "NeckId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "OffHandId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "RinegOneId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "RingTwoId",
                table: "EquippedItems");

            migrationBuilder.DropColumn(
                name: "WaistId",
                table: "EquippedItems");
        }
    }
}
