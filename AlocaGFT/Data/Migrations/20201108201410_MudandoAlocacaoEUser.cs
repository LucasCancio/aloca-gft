using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class MudandoAlocacaoEUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogAlocacoes");

            migrationBuilder.AddColumn<int>(
                name: "level",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alocacoes",
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
                    table.PrimaryKey("PK_Alocacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Funcionarios_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alocacoes_AspNetUsers_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Vagas_vagaid",
                        column: x => x.vagaid,
                        principalTable: "Vagas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_funcionarioid",
                table: "Alocacoes",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_usuarioId",
                table: "Alocacoes",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_vagaid",
                table: "Alocacoes",
                column: "vagaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alocacoes");

            migrationBuilder.DropColumn(
                name: "level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "LogAlocacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_alocado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    funcionarioid = table.Column<int>(type: "int", nullable: true),
                    usuarioId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    vagaid = table.Column<int>(type: "int", nullable: true)
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
    }
}
