using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class MudandoDefaultCrudEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_alteracao",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "Enderecos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Enderecos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_alteracao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Enderecos");
        }
    }
}
