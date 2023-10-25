using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace geoprofs.Migrations
{
    public partial class verlof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verlof",
                columns: table => new
                {
                    VerlofId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerlofReden = table.Column<int>(type: "int", nullable: false),
                    VerlofOmschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginVerlof = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindVerlof = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerlofResterend = table.Column<int>(type: "int", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerlofStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verlof", x => x.VerlofId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verlof");
        }
    }
}
