using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class AdicionandoCargoLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "level",
                table: "Cargos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                table: "Cargos");
        }
    }
}
