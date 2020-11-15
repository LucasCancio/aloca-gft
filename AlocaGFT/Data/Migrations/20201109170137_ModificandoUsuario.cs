using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class ModificandoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "AspNetUsers",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "AspNetUsers",
                newName: "Level");

            migrationBuilder.AlterColumn<string>(
                name: "uf",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bairro",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AspNetUsers",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "AspNetUsers",
                newName: "level");

            migrationBuilder.AddColumn<int>(
                name: "enderecoid",
                table: "Vagas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "uf",
                table: "Enderecos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "Enderecos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "Enderecos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "Enderecos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "bairro",
                table: "Enderecos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
