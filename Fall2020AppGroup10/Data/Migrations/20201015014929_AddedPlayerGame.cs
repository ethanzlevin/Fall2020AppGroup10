using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class AddedPlayerGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerGameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false),
                    Fouls = table.Column<int>(nullable: false),
                    Rebounds = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => x.PlayerGameID);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerID",
                table: "PlayerGame",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGame");
        }
    }
}
