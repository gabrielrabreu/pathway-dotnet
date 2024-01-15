using Microsoft.EntityFrameworkCore.Migrations;

namespace Something.Infra.Data.Migrations
{
    public partial class ImportLayoutColumnFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "ImportLayoutColumn",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "ImportLayoutColumn");
        }
    }
}
