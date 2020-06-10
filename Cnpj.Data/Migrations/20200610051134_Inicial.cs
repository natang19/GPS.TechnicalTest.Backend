using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cnpj.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    data_situacao = table.Column<DateTime>(type: "date", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(1000)", nullable: false),
                    situacao = table.Column<string>(type: "varchar(200)", nullable: false),
                    bairro = table.Column<string>(type: "varchar(200)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    municipio = table.Column<string>(type: "varchar(200)", nullable: false),
                    porte = table.Column<string>(type: "varchar(15)", nullable: false),
                    abertura = table.Column<DateTime>(type: "date", nullable: false),
                    natureza_juridica = table.Column<string>(type: "varchar(100)", nullable: false),
                    fantasia = table.Column<string>(type: "varchar(250)", nullable: false),
                    cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    ultima_atualizacao = table.Column<DateTime>(type: "date", nullable: false),
                    tipo = table.Column<string>(type: "varchar(6)", nullable: false),
                    complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    efr = table.Column<string>(type: "varchar(100)", nullable: true),
                    motivo_situacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    situacao_especial = table.Column<string>(type: "varchar(100)", nullable: true),
                    data_situacao_especial = table.Column<string>(type: "varchar(100)", nullable: true),
                    capital_social = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
