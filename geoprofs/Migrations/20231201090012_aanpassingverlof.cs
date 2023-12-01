using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace geoprofs.Migrations
{
    public partial class aanpassingverlof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VerlofReden",
                table: "Verlof",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApproveDeny",
                table: "Verlof",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDeny",
                table: "Verlof");

            migrationBuilder.AlterColumn<int>(
                name: "VerlofReden",
                table: "Verlof",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
