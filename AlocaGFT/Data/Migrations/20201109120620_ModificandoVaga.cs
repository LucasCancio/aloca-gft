using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class ModificandoVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "enderecoid",
                table: "Vagas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "home_office",
                table: "Vagas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_enderecoid",
                table: "Vagas",
                column: "enderecoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Enderecos_enderecoid",
                table: "Vagas",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Enderecos_enderecoid",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_enderecoid",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "enderecoid",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "home_office",
                table: "Vagas");
        }
    }
}
