using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class tablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Tenant",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDate",
                table: "Tenant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "FeeDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "DailyWage",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDate",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "FeeDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DailyWage");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Tenant",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
