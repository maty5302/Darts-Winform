using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace šipky_Forms.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    Average = table.Column<double>(type: "REAL", nullable: false),
                    highestOut = table.Column<int>(type: "INTEGER", nullable: false),
                    sixty = table.Column<int>(type: "INTEGER", nullable: false),
                    hundred = table.Column<int>(type: "INTEGER", nullable: false),
                    hundred20 = table.Column<int>(type: "INTEGER", nullable: false),
                    hundred80 = table.Column<int>(type: "INTEGER", nullable: false),
                    AllWins = table.Column<int>(type: "INTEGER", nullable: false),
                    OldhighestOut = table.Column<int>(type: "INTEGER", nullable: false),
                    Allsixty = table.Column<int>(type: "INTEGER", nullable: false),
                    Allhundred = table.Column<int>(type: "INTEGER", nullable: false),
                    Allhundred20 = table.Column<int>(type: "INTEGER", nullable: false),
                    Allhundred80 = table.Column<int>(type: "INTEGER", nullable: false),
                    firstWin = table.Column<bool>(type: "INTEGER", nullable: false),
                    _20Wins = table.Column<bool>(type: "INTEGER", nullable: false),
                    _100Wins = table.Column<bool>(type: "INTEGER", nullable: false),
                    first180 = table.Column<bool>(type: "INTEGER", nullable: false),
                    profesional = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PicturePath = table.Column<string>(type: "TEXT", nullable: false),
                    muteSounds = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPanels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BackColorAsArgb = table.Column<int>(type: "INTEGER", nullable: false),
                    UserSettingsId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPanels_UserSettings_UserSettingsId",
                        column: x => x.UserSettingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPanels_UserSettingsId",
                table: "PlayerPanels",
                column: "UserSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerPanels");

            migrationBuilder.DropTable(
                name: "PlayerSettings");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
