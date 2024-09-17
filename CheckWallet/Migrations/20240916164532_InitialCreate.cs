using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckWallet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatcherSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChainId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RpcUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIntervalMsecs = table.Column<int>(type: "int", nullable: false),
                    WeiBalanceThreshold = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    CreateTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTs = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatcherSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountWatchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChainId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WatcherSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTs = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountWatchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountWatchers_WatcherSettings_WatcherSettingsId",
                        column: x => x.WatcherSettingsId,
                        principalTable: "WatcherSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountWatchers_WatcherSettingsId",
                table: "AccountWatchers",
                column: "WatcherSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountWatchers");

            migrationBuilder.DropTable(
                name: "WatcherSettings");
        }
    }
}
