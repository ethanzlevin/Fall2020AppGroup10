using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class allTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Division = table.Column<string>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

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
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    RookieYear = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsPerGame = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssistsPerGame = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FieldGoalPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    BetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPlaced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payout = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Odds = table.Column<short>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Result = table.Column<bool>(nullable: true),
                    BetType = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    PlayerGameID = table.Column<int>(nullable: true),
                    GameID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    WinningTeam = table.Column<string>(nullable: true),
                    GameID1 = table.Column<int>(nullable: true),
                    StrikeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlayerGameID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetID);
                    table.ForeignKey(
                        name: "FK_Bet_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_PlayerGame_PlayerGameID",
                        column: x => x.PlayerGameID,
                        principalTable: "PlayerGame",
                        principalColumn: "PlayerGameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_Game_GameID1",
                        column: x => x.GameID1,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_PlayerGame_PlayerGameID1",
                        column: x => x.PlayerGameID1,
                        principalTable: "PlayerGame",
                        principalColumn: "PlayerGameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameID",
                table: "Bet",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerGameID",
                table: "Bet",
                column: "PlayerGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserID",
                table: "Bet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameID1",
                table: "Bet",
                column: "GameID1");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PlayerGameID1",
                table: "Bet",
                column: "PlayerGameID1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_AwayID",
                table: "Game",
                column: "AwayID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserID",
                table: "Payment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameID",
                table: "PlayerGame",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerID",
                table: "PlayerGame",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

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
