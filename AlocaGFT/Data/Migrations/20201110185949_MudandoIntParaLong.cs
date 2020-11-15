using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class MudandoIntParaLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_Funcionarios_funcionarioid",
                table: "Alocacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_Vagas_vagaid",
                table: "Alocacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_cargoid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Gfts_gftid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Gfts_Enderecos_enderecoid",
                table: "Gfts");

            migrationBuilder.AlterColumn<long>(
                name: "vagaid",
                table: "Vagas_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "tecnologiaid",
                table: "Vagas_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Vagas_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Vagas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "enderecoid",
                table: "Gfts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Gfts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "tecnologiaid",
                table: "Funcionarios_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "funcionarioid",
                table: "Funcionarios_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Funcionarios_Tecnologias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "vagaid",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "gftid",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "cargoid",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Cargos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "vagaid",
                table: "Alocacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "funcionarioid",
                table: "Alocacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_Alocacoes_Funcionarios_funcionarioid",
                table: "Alocacoes",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacoes_Vagas_vagaid",
                table: "Alocacoes",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_cargoid",
                table: "Funcionarios",
                column: "cargoid",
                principalTable: "Cargos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Gfts_gftid",
                table: "Funcionarios",
                column: "gftid",
                principalTable: "Gfts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Tecnologias_Funcionarios_funcionarioid",
                table: "Funcionarios_Tecnologias",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Tecnologias_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias",
                column: "tecnologiaid",
                principalTable: "Tecnologias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gfts_Enderecos_enderecoid",
                table: "Gfts",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Tecnologias_Tecnologias_tecnologiaid",
                table: "Vagas_Tecnologias",
                column: "tecnologiaid",
                principalTable: "Tecnologias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Tecnologias_Vagas_vagaid",
                table: "Vagas_Tecnologias",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_Funcionarios_funcionarioid",
                table: "Alocacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_Vagas_vagaid",
                table: "Alocacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_cargoid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Gfts_gftid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Tecnologias_Funcionarios_funcionarioid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Tecnologias_Tecnologias_tecnologiaid",
                table: "Funcionarios_Tecnologias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gfts_Enderecos_enderecoid",
                table: "Gfts");

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
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Vagas_Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Vagas_Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Vagas",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "enderecoid",
                table: "Gfts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Gfts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "tecnologiaid",
                table: "Funcionarios_Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Funcionarios_Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Funcionarios_Tecnologias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vagaid",
                table: "Funcionarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "gftid",
                table: "Funcionarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "cargoid",
                table: "Funcionarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Cargos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vagaid",
                table: "Alocacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Alocacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacoes_Funcionarios_funcionarioid",
                table: "Alocacoes",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacoes_Vagas_vagaid",
                table: "Alocacoes",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_cargoid",
                table: "Funcionarios",
                column: "cargoid",
                principalTable: "Cargos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Gfts_gftid",
                table: "Funcionarios",
                column: "gftid",
                principalTable: "Gfts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gfts_Enderecos_enderecoid",
                table: "Gfts",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
