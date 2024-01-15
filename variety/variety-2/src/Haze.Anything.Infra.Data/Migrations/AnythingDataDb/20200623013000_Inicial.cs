using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haze.Anything.Infra.Data.Migrations.AnythingDataDb
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fulano",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tenant = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fulano", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fulano");
        }
    }
}
