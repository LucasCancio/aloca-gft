using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class RemovendoRelacionamentoNparaN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Tecnologias_Funcionarios_funcionarioid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Tecnologias_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Tecnologias_Tecnologias_tecnologiaid",
                table: "Vagas_Tecnologias");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Tecnologias_Vagas_vagaid",
                table: "Vagas_Tecnologias");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_Tecnologias_tecnologiaid",
                table: "Vagas_Tecnologias");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_Tecnologias_vagaid",
                table: "Vagas_Tecnologias");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_Tecnologias_funcionarioid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.AlterColumn<int>(
                name: "vagaid",
                table: "Vagas_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Vagas_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Funcionarios_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Funcionarios_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Alocacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "vagaid",
                table: "Vagas_Tecnologias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Vagas_Tecnologias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Funcionarios_Tecnologias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Funcionarios_Tecnologias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Alocacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_Tecnologias_tecnologiaid",
                table: "Vagas_Tecnologias",
                column: "tecnologiaid");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_Tecnologias_vagaid",
                table: "Vagas_Tecnologias",
                column: "vagaid");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Tecnologias_funcionarioid",
                table: "Funcionarios_Tecnologias",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias",
                column: "tecnologiaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Tecnologias_Funcionarios_funcionarioid",
                table: "Funcionarios_Tecnologias",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Tecnologias_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias",
                column: "tecnologiaid",
                principalTable: "Tecnologias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Tecnologias_Tecnologias_tecnologiaid",
                table: "Vagas_Tecnologias",
                column: "tecnologiaid",
                principalTable: "Tecnologias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Tecnologias_Vagas_vagaid",
                table: "Vagas_Tecnologias",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
