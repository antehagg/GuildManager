using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildManager.Api.Migrations
{
    public partial class AddedMonsters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseResourcesId = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    MonsterType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_BaseResources_BaseResourcesId",
                        column: x => x.BaseResourcesId,
                        principalTable: "BaseResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monsters_GameClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "GameClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monsters_DbInventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "DbInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_BaseResourcesId",
                table: "Monsters",
                column: "BaseResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_ClassId",
                table: "Monsters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_InventoryId",
                table: "Monsters",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
