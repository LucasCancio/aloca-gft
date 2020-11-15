using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class RemovendoEntidadeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_AspNetUsers_usuarioId",
                table: "Alocacoes");

            migrationBuilder.DropIndex(
                name: "IX_Alocacoes_usuarioId",
                table: "Alocacoes");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Alocacoes");

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Alocacoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Alocacoes");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usuarioId",
                table: "Alocacoes",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_usuarioId",
                table: "Alocacoes",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacoes_AspNetUsers_usuarioId",
                table: "Alocacoes",
                column: "usuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
