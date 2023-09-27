using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedNewGuestTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestDetails",
                columns: table => new
                {
                    GuestDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<byte>(type: "tinyint", nullable: true),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    FkbranchId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDetails", x => x.GuestDetailId);
                    table.ForeignKey(
                        name: "FK_GuestDetails_Branch_FkbranchId",
                        column: x => x.FkbranchId,
                        principalTable: "Branch",
                        principalColumn: "PKBranchId");
                });

            migrationBuilder.CreateTable(
                name: "GuestUsers",
                columns: table => new
                {
                    GuestUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: true),
                    ProofName = table.Column<byte>(type: "tinyint", nullable: true),
                    ProodId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    FkGuestDetailId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestUsers", x => x.GuestUserId);
                    table.ForeignKey(
                        name: "FK_GuestUsers_GuestDetails_FkGuestDetailId",
                        column: x => x.FkGuestDetailId,
                        principalTable: "GuestDetails",
                        principalColumn: "GuestDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestDetails_FkbranchId",
                table: "GuestDetails",
                column: "FkbranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestUsers_FkGuestDetailId",
                table: "GuestUsers",
                column: "FkGuestDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestUsers");

            migrationBuilder.DropTable(
                name: "GuestDetails");
        }
    }
}
