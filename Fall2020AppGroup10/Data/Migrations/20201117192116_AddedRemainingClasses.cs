using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class AddedRemainingClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoursWorked",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Favorite = table.Column<bool>(nullable: true),
                    Score = table.Column<int>(nullable: true),
                    HomeID = table.Column<int>(nullable: false),
                    AwayID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_Team_AwayID",
                        column: x => x.AwayID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(nullable: false),
                    StartingDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameBet",
                columns: table => new
                {
                    GameBetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odds = table.Column<decimal>(nullable: true),
                    HomeScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AwayScore = table.Column<int>(nullable: true),
                    GameID = table.Column<int>(nullable: false)
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
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerGameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(nullable: false),
                    Points = table.Column<int>(nullable: true),
                    Assists = table.Column<int>(nullable: true),
                    Blocks = table.Column<int>(nullable: true),
                    Fouls = table.Column<int>(nullable: true),
                    Rebounds = table.Column<int>(nullable: true),
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => x.PlayerGameID);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBet",
                columns: table => new
                {
                    PlayerBetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrikeValue = table.Column<decimal>(nullable: false),
                    PlayerGameID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    BetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPlaced = table.Column<decimal>(nullable: false),
                    Payout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: false),
                    PlayerBetID = table.Column<int>(nullable: false),
                    GameBetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetID);
                    table.ForeignKey(
                        name: "FK_Bet_GameBet_GameBetID",
                        column: x => x.GameBetID,
                        principalTable: "GameBet",
                        principalColumn: "GameBetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_PlayerBet_PlayerBetID",
                        column: x => x.PlayerBetID,
                        principalTable: "PlayerBet",
                        principalColumn: "PlayerBetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameBetID",
                table: "Bet",
                column: "GameBetID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerBetID",
                table: "Bet",
                column: "PlayerBetID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserID",
                table: "Bet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_AwayID",
                table: "Game",
                column: "AwayID");

            migrationBuilder.CreateIndex(
                name: "IX_GameBet_GameID",
                table: "GameBet",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserID",
                table: "Payment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBet_PlayerGameID",
                table: "PlayerBet",
                column: "PlayerGameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameID",
                table: "PlayerGame",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerID",
                table: "PlayerGame",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamID",
                table: "Player",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamID",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "GameBet");

            migrationBuilder.DropTable(
                name: "PlayerBet");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamID",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
