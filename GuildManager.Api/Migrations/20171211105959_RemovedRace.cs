using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class RemovedRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbRace_RaceId",
                table: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "DbRace");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_RaceId",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "PlayerCharacters");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "PlayerCharacters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "DbItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DbInventoryId",
                table: "DbItem",
                nullable: true);

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
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters",
                column: "InventoryId",
                principalTable: "DbInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbInventory_DbInventoryId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_DbInventory_InventoryId",
                table: "PlayerCharacters");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_DbInventoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DbInventoryId",
                table: "DbItem");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "PlayerCharacters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "PlayerCharacters",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_RaceId",
                table: "PlayerCharacters",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_ItemStats_StatsId",
                table: "DbItem",
                column: "StatsId",
                principalTable: "ItemStats",
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
                name: "FK_PlayerCharacters_DbRace_RaceId",
                table: "PlayerCharacters",
                column: "RaceId",
                principalTable: "DbRace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
