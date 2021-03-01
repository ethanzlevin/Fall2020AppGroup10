using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class fixedBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Game_GameID",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Game_GameID1",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID1",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_GameID1",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_PlayerGameID1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "GameID1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "PlayerGameID1",
                table: "Bet");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Game_GameID",
                table: "Bet",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID",
                table: "Bet",
                column: "PlayerGameID",
                principalTable: "PlayerGame",
                principalColumn: "PlayerGameID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Game_GameID",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID",
                table: "Bet");

            migrationBuilder.AddColumn<int>(
                name: "GameID1",
                table: "Bet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameID1",
                table: "Bet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameID1",
                table: "Bet",
                column: "GameID1");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerGameID1",
                table: "Bet",
                column: "PlayerGameID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Game_GameID",
                table: "Bet",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID",
                table: "Bet",
                column: "PlayerGameID",
                principalTable: "PlayerGame",
                principalColumn: "PlayerGameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Game_GameID1",
                table: "Bet",
                column: "GameID1",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_PlayerGame_PlayerGameID1",
                table: "Bet",
                column: "PlayerGameID1",
                principalTable: "PlayerGame",
                principalColumn: "PlayerGameID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
