using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup10.Data.Migrations
{
    public partial class AddedBetStartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetID);
                    table.ForeignKey(
                        name: "FK_Bet_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserID",
                table: "Bet",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");
        }
    }
}
