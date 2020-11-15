using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class CriandoLogAlocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "codigo_vaga",
                table: "Vagas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Cargos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "LogAlocacoes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vagaid = table.Column<int>(nullable: true),
                    funcionarioid = table.Column<int>(nullable: true),
                    data_alocado = table.Column<DateTime>(nullable: false),
                    usuarioId = table.Column<string>(nullable: true),
                    data_criacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAlocacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_LogAlocacoes_Funcionarios_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogAlocacoes_AspNetUsers_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogAlocacoes_Vagas_vagaid",
                        column: x => x.vagaid,
                        principalTable: "Vagas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogAlocacoes_funcionarioid",
                table: "LogAlocacoes",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_LogAlocacoes_usuarioId",
                table: "LogAlocacoes",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogAlocacoes_vagaid",
                table: "LogAlocacoes",
                column: "vagaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogAlocacoes");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "codigo_vaga",
                table: "Vagas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
