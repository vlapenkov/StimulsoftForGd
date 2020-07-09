using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportSettings",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    FileBody = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportData",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    ReportSettingsId = table.Column<string>(maxLength: 128, nullable: true),
                    FileBody = table.Column<byte[]>(nullable: true),
                    FileType = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportData_ReportSettings_ReportSettingsId",
                        column: x => x.ReportSettingsId,
                        principalTable: "ReportSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportData_ReportSettingsId",
                table: "ReportData",
                column: "ReportSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportData");

            migrationBuilder.DropTable(
                name: "ReportSettings");
        }
    }
}
