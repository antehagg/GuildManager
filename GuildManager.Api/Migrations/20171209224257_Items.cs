using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseHealth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseAgility = table.Column<int>(nullable: false),
                    BaseIntelligence = table.Column<int>(nullable: false),
                    BaseStamina = table.Column<int>(nullable: false),
                    BaseStrength = table.Column<int>(nullable: false),
                    BaseWisdom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbRace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agility = table.Column<int>(nullable: false),
                    CritChance = table.Column<double>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    Haste = table.Column<double>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseResourcesId = table.Column<int>(nullable: false),
                    BaseStatsId = table.Column<int>(nullable: false),
                    MainStat = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameClasses_BaseResources_BaseResourcesId",
                        column: x => x.BaseResourcesId,
                        principalTable: "BaseResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameClasses_BaseStats_BaseStatsId",
                        column: x => x.BaseStatsId,
                        principalTable: "BaseStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    ItemRarity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StatsId = table.Column<int>(nullable: true),
                    EquipSlotType = table.Column<int>(nullable: true),
                    MaxDamage = table.Column<int>(nullable: true),
                    MinDamage = table.Column<int>(nullable: true),
                    SwingSpeed = table.Column<double>(nullable: true),
                    WeaponEquipType = table.Column<int>(nullable: true),
                    WeaponType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbItem_ItemStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "ItemStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbEquipedItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainHandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEquipedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbEquipedItems_DbItem_MainHandId",
                        column: x => x.MainHandId,
                        principalTable: "DbItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(nullable: false),
                    EquipedItemsId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_GameClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "GameClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_DbEquipedItems_EquipedItemsId",
                        column: x => x.EquipedItemsId,
                        principalTable: "DbEquipedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_DbInventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "DbInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_DbRace_RaceId",
                        column: x => x.RaceId,
                        principalTable: "DbRace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbEquipedItems_MainHandId",
                table: "DbEquipedItems",
                column: "MainHandId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_StatsId",
                table: "DbItem",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameClasses_BaseResourcesId",
                table: "GameClasses",
                column: "BaseResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameClasses_BaseStatsId",
                table: "GameClasses",
                column: "BaseStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_ClassId",
                table: "PlayerCharacters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_EquipedItemsId",
                table: "PlayerCharacters",
                column: "EquipedItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_InventoryId",
                table: "PlayerCharacters",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_RaceId",
                table: "PlayerCharacters",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "GameClasses");

            migrationBuilder.DropTable(
                name: "DbEquipedItems");

            migrationBuilder.DropTable(
                name: "DbInventory");

            migrationBuilder.DropTable(
                name: "DbRace");

            migrationBuilder.DropTable(
                name: "BaseResources");

            migrationBuilder.DropTable(
                name: "BaseStats");

            migrationBuilder.DropTable(
                name: "DbItem");

            migrationBuilder.DropTable(
                name: "ItemStats");
        }
    }
}
