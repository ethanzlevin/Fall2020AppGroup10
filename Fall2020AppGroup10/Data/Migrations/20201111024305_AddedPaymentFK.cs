using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class AddedPaymentFK : Migration
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
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(nullable: false),
                    StartingDeposit = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
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
                name: "IX_Payment_UserID",
                table: "Payment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerID",
                table: "PlayerGame",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PlayerGame");

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
