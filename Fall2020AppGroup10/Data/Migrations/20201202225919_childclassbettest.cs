using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class childclassbettest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_GameBet_GameBetID",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_PlayerBet_PlayerBetID",
                table: "Bet");

            migrationBuilder.DropTable(
                name: "GameBet");

            migrationBuilder.DropTable(
                name: "PlayerBet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_GameBetID",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_PlayerBetID",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "GameBetID",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "PlayerBetID",
                table: "Bet");

            migrationBuilder.AlterColumn<bool>(
                name: "Result",
                table: "Bet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Payout",
                table: "Bet",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "BetType",
                table: "Bet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Bet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Odds",
                table: "Bet",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameID",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameID1",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinningTeam",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameID1",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StrikeValue",
                table: "Bet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameID",
                table: "Bet",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerGameID",
                table: "Bet",
                column: "PlayerGameID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Bet_GameID",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_PlayerGameID",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_GameID1",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_PlayerGameID1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "BetType",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "Odds",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "PlayerGameID",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "GameID1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "WinningTeam",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "PlayerGameID1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "StrikeValue",
                table: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Bet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Payout",
                table: "Bet",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameBetID",
                table: "Bet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerBetID",
                table: "Bet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameBet",
                columns: table => new
                {
                    GameBetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwayScore = table.Column<int>(type: "int", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    HomeScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Odds = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBet", x => x.GameBetID);
                    table.ForeignKey(
                        name: "FK_GameBet_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBet",
                columns: table => new
                {
                    PlayerBetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerGameID = table.Column<int>(type: "int", nullable: false),
                    StrikeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBet", x => x.PlayerBetID);
                    table.ForeignKey(
                        name: "FK_PlayerBet_PlayerGame_PlayerGameID",
                        column: x => x.PlayerGameID,
                        principalTable: "PlayerGame",
                        principalColumn: "PlayerGameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameBetID",
                table: "Bet",
                column: "GameBetID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerBetID",
                table: "Bet",
                column: "PlayerBetID");

            migrationBuilder.CreateIndex(
                name: "IX_GameBet_GameID",
                table: "GameBet",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBet_PlayerGameID",
                table: "PlayerBet",
                column: "PlayerGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_GameBet_GameBetID",
                table: "Bet",
                column: "GameBetID",
                principalTable: "GameBet",
                principalColumn: "GameBetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_PlayerBet_PlayerBetID",
                table: "Bet",
                column: "PlayerBetID",
                principalTable: "PlayerBet",
                principalColumn: "PlayerBetID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
