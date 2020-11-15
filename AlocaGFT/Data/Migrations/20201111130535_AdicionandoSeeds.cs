using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlocaGFT.Migrations
{
    public partial class AdicionandoSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<long>(
                name: "vagaid",
                table: "Funcionarios",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "id", "data_alteracao", "data_criacao", "level", "nome", "status" },
                values: new object[] { 1L, null, new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(7872), 0, "Starter", true });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "id", "bairro", "cep", "cidade", "complemento", "data_alteracao", "data_criacao", "latitude", "logradouro", "longitude", "numero", "status", "uf" },
                values: new object[,]
                {
                    { 1L, "Alphaville Industrial", "06454-000", "Barueri", null, null, new DateTime(2020, 11, 11, 10, 5, 35, 64, DateTimeKind.Local).AddTicks(8713), -23.500498f, "Alameda Rio Negro", -46.850864f, 585, true, "SP" },
                    { 2L, "Jardim Santa Rosália", "18095-450", "Sorocaba", null, null, new DateTime(2020, 11, 11, 10, 5, 35, 67, DateTimeKind.Local).AddTicks(7951), -23.487108f, "Av. São Francisco", -47.444813f, 98, true, "SP" }
                });

            migrationBuilder.InsertData(
                table: "Tecnologias",
                columns: new[] { "id", "data_alteracao", "data_criacao", "imageName", "nome", "status" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(3990), "dotnet-icon.png", "DotNet", true },
                    { 2L, null, new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(6091), "java-icon.png", "Java", true },
                    { 3L, null, new DateTime(2020, 11, 11, 10, 5, 35, 69, DateTimeKind.Local).AddTicks(6199), "swift-icon.png", "Swift", true }
                });

            migrationBuilder.InsertData(
                table: "Vagas",
                columns: new[] { "id", "abertura", "codigo_vaga", "data_alteracao", "data_criacao", "descricao", "home_office", "projeto", "qtd_vaga", "status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(3596), "#ITAU-2020-11", null, new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(2767), "Desenvolvedor Java Senior", true, "Itau", 2, true },
                    { 2L, new DateTime(2021, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(6387), "#SANTANDER-2021-11", null, new DateTime(2020, 11, 11, 10, 5, 35, 70, DateTimeKind.Local).AddTicks(6359), "Desenvolvedor IOS", false, "Santander", 1, true }
                });

            migrationBuilder.InsertData(
                table: "Gfts",
                columns: new[] { "id", "data_alteracao", "data_criacao", "enderecoid", "nome", "status", "telefone" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(1925), 1L, "GFT Alphaville", true, "(11)2176-3253" },
                    { 2L, null, new DateTime(2020, 11, 11, 10, 5, 35, 68, DateTimeKind.Local).AddTicks(4289), 2L, "GFT Sorocaba", true, "(11)2176-3253" }
                });

            migrationBuilder.InsertData(
                table: "Vagas_Tecnologias",
                columns: new[] { "id", "tecnologiaid", "vagaid" },
                values: new object[,]
                {
                    { 1L, 2L, 1L },
                    { 2L, 3L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "cargoid", "data_alteracao", "data_criacao", "gftid", "inicio_wa", "matricula", "nome", "status", "termino_wa", "vagaid" },
                values: new object[] { 1L, 1L, null, new DateTime(2020, 11, 11, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(2778), 1L, new DateTime(2020, 11, 11, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(4364), "N412302", "Lucas Camargo", true, new DateTime(2020, 11, 26, 10, 5, 35, 71, DateTimeKind.Local).AddTicks(4768), null });

            migrationBuilder.InsertData(
                table: "Funcionarios_Tecnologias",
                columns: new[] { "id", "funcionarioid", "tecnologiaid" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios");

            migrationBuilder.DeleteData(
                table: "Funcionarios_Tecnologias",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Vagas_Tecnologias",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Vagas_Tecnologias",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tecnologias",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Vagas",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Gfts",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "vagaid",
                table: "Funcionarios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Vagas_vagaid",
                table: "Funcionarios",
                column: "vagaid",
                principalTable: "Vagas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
