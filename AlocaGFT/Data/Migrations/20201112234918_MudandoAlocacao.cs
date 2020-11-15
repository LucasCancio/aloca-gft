using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class MudandoAlocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_alocado",
                table: "Alocacoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_operacao",
                table: "Alocacoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "operacao",
                table: "Alocacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "id",
                keyValue: 1L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 12, 20, 49, 17, 263, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 1L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 12, 20, 49, 17, 259, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 2L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 12, 20, 49, 17, 262, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "inicio_wa", "status", "termino_wa" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 265, DateTimeKind.Local).AddTicks(8082), new DateTime(2020, 11, 12, 20, 49, 17, 265, DateTimeKind.Local).AddTicks(9501), true, new DateTime(2020, 11, 27, 20, 49, 17, 265, DateTimeKind.Local).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 262, DateTimeKind.Local).AddTicks(8971), true });

            migrationBuilder.UpdateData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 263, DateTimeKind.Local).AddTicks(1444), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 263, DateTimeKind.Local).AddTicks(9338), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 264, DateTimeKind.Local).AddTicks(1394), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 264, DateTimeKind.Local).AddTicks(1507), true });

            migrationBuilder.UpdateData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "abertura", "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 12, 20, 49, 17, 264, DateTimeKind.Local).AddTicks(9007), new DateTime(2020, 11, 12, 20, 49, 17, 264, DateTimeKind.Local).AddTicks(8189), true });

            migrationBuilder.UpdateData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "abertura", "data_criacao", "status" },
                values: new object[] { new DateTime(2021, 11, 12, 20, 49, 17, 265, DateTimeKind.Local).AddTicks(2052), new DateTime(2020, 11, 12, 20, 49, 17, 265, DateTimeKind.Local).AddTicks(2013), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_operacao",
                table: "Alocacoes");

            migrationBuilder.DropColumn(
                name: "operacao",
                table: "Alocacoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_alocado",
                table: "Alocacoes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "id",
                keyValue: 1L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 1L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 11, 10, 5, 35, 64, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 2L,
                column: "data_criacao",
                value: new DateTime(2020, 11, 11, 10, 5, 35, 67, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "inicio_wa", "status", "termino_wa" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(2778), new DateTime(2020, 11, 11, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(4364), true, new DateTime(2020, 11, 26, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(1925), true });

            migrationBuilder.UpdateData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(4289), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(3990), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(6091), true });

            migrationBuilder.UpdateData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(6199), true });

            migrationBuilder.UpdateData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "abertura", "data_criacao", "status" },
                values: new object[] { new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(3596), new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(2767), true });

            migrationBuilder.UpdateData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "abertura", "data_criacao", "status" },
                values: new object[] { new DateTime(2021, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(6387), new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(6359), true });
        }
    }
}
