using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Wagestableadd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyWage",
                columns: table => new
                {
                    PKDailyWageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WageType = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkbranchId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fkcreatedby = table.Column<int>(type: "int", nullable: true),
                    FkmodifiedBy = table.Column<int>(type: "int", nullable: true),
                    FkhostelPkhostelId = table.Column<int>(type: "int", nullable: true),
                    FkcreatedbyNavigationPkuserId = table.Column<int>(type: "int", nullable: true),
                    FkmodifiedByNavigationPkuserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DailyWage__B96213F4837A76E6", x => x.PKDailyWageId);
                    table.ForeignKey(
                        name: "FK_DailyWage_Branch_FkbranchId",
                        column: x => x.FkbranchId,
                        principalTable: "Branch",
                        principalColumn: "PKBranchId");
                    table.ForeignKey(
                        name: "FK_DailyWage_Hostel_FkhostelPkhostelId",
                        column: x => x.FkhostelPkhostelId,
                        principalTable: "Hostel",
                        principalColumn: "PKHostelId");
                    table.ForeignKey(
                        name: "FK_DailyWage_UserProfile_FkcreatedbyNavigationPkuserId",
                        column: x => x.FkcreatedbyNavigationPkuserId,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                    table.ForeignKey(
                        name: "FK_DailyWage_UserProfile_FkmodifiedByNavigationPkuserId",
                        column: x => x.FkmodifiedByNavigationPkuserId,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyWage_FkbranchId",
                table: "DailyWage",
                column: "FkbranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyWage_FkcreatedbyNavigationPkuserId",
                table: "DailyWage",
                column: "FkcreatedbyNavigationPkuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyWage_FkhostelPkhostelId",
                table: "DailyWage",
                column: "FkhostelPkhostelId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyWage_FkmodifiedByNavigationPkuserId",
                table: "DailyWage",
                column: "FkmodifiedByNavigationPkuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyWage");
        }
    }
}
