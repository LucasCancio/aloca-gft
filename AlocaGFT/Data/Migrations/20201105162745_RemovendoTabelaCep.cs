using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class RemovendoTabelaCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Ceps_cepcod",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "Ceps");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_cepcod",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "cepcod",
                table: "Enderecos");

            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "logradouro",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "Enderecos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "logradouro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "Enderecos");

            migrationBuilder.AddColumn<string>(
                name: "cepcod",
                table: "Enderecos",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ceps",
                columns: table => new
                {
                    cod = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    cidade = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    logradouro = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    uf = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceps", x => x.cod);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_cepcod",
                table: "Enderecos",
                column: "cepcod");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Ceps_cepcod",
                table: "Enderecos",
                column: "cepcod",
                principalTable: "Ceps",
                principalColumn: "cod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
