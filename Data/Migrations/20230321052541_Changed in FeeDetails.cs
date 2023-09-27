using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ChangedinFeeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "FeeDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedAmount",
                table: "FeeDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedAmount",
                table: "FeeDetails");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "FeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
