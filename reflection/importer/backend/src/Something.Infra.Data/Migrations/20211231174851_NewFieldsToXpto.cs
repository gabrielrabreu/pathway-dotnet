using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Something.Infra.Data.Migrations
{
    public partial class NewFieldsToXpto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Xpto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Xpto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Xpto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Xpto");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Xpto");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Xpto");
        }
    }
}
