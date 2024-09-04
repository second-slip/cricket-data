using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cricket_data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grounds",
                columns: table => new
                {
                    GroundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grounds", x => x.GroundId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CricInfoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "BowlingInnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Overs = table.Column<float>(type: "real", nullable: false),
                    Maidens = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Wickets = table.Column<int>(type: "int", nullable: false),
                    Economy = table.Column<float>(type: "real", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Innings = table.Column<int>(type: "int", nullable: false),
                    Opposition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroundId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlingInnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BowlingInnings_Grounds_GroundId",
                        column: x => x.GroundId,
                        principalTable: "Grounds",
                        principalColumn: "GroundId");
                    table.ForeignKey(
                        name: "FK_BowlingInnings_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BowlingInnings_GroundId",
                table: "BowlingInnings",
                column: "GroundId");

            migrationBuilder.CreateIndex(
                name: "IX_BowlingInnings_PlayerId",
                table: "BowlingInnings",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BowlingInnings");

            migrationBuilder.DropTable(
                name: "Grounds");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
