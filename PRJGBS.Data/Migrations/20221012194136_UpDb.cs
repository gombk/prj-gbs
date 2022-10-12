using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRJGBS.Data.Migrations
{
    public partial class UpDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NpcDialogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DialogueText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PromptA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PromptB = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NpcDialogue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StoryProgress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Npc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Affinity = table.Column<int>(type: "int", nullable: false),
                    NPCDialogueID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npc_NpcDialogue_NPCDialogueID",
                        column: x => x.NPCDialogueID,
                        principalTable: "NpcDialogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SaveStateId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_SaveState_SaveStateId",
                        column: x => x.SaveStateId,
                        principalTable: "SaveState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Npc_NPCDialogueID",
                table: "Npc",
                column: "NPCDialogueID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_SaveStateId",
                table: "Player",
                column: "SaveStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Npc");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "NpcDialogue");

            migrationBuilder.DropTable(
                name: "SaveState");
        }
    }
}
