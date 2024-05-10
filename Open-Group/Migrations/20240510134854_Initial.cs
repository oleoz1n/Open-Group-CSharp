using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open_Group.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_OP_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Identificacao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OP_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "T_OP_DADOS_CLIENTE",
                columns: table => new
                {
                    ID_DADOS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Segmento = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TEMPO_ATUACAO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    NUM_FUNCIONARIOS = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    FATURAMENTO_ANUAL = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    CANAL_VENDA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PRODUTO_SERVICO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Porte = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Concorrente = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Desafio = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Objetivo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    USUARIO_DADOS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OP_DADOS_CLIENTE", x => x.ID_DADOS);
                    table.ForeignKey(
                        name: "FK_T_OP_DADOS_CLIENTE_T_OP_USUARIO_USUARIO_DADOS",
                        column: x => x.USUARIO_DADOS,
                        principalTable: "T_OP_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OP_ARQUIVO",
                columns: table => new
                {
                    ID_ARQUIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Tamanho = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DATA_UPLOAD = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Link = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    PALAVRA_CHAVE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Resumo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DADOS_ARQUIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OP_ARQUIVO", x => x.ID_ARQUIVO);
                    table.ForeignKey(
                        name: "FK_T_OP_ARQUIVO_T_OP_DADOS_CLIENTE_DADOS_ARQUIVO",
                        column: x => x.DADOS_ARQUIVO,
                        principalTable: "T_OP_DADOS_CLIENTE",
                        principalColumn: "ID_DADOS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OP_INSIGHT",
                columns: table => new
                {
                    ID_INSIGHT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA_GERACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Detalhes = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Recomendacao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Impacto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DADOS_INSIGHT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OP_INSIGHT", x => x.ID_INSIGHT);
                    table.ForeignKey(
                        name: "FK_T_OP_INSIGHT_T_OP_DADOS_CLIENTE_DADOS_INSIGHT",
                        column: x => x.DADOS_INSIGHT,
                        principalTable: "T_OP_DADOS_CLIENTE",
                        principalColumn: "ID_DADOS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_ARQUIVO_DADOS_ARQUIVO",
                table: "T_OP_ARQUIVO",
                column: "DADOS_ARQUIVO");

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_DADOS_CLIENTE_USUARIO_DADOS",
                table: "T_OP_DADOS_CLIENTE",
                column: "USUARIO_DADOS");

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_INSIGHT_DADOS_INSIGHT",
                table: "T_OP_INSIGHT",
                column: "DADOS_INSIGHT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_OP_ARQUIVO");

            migrationBuilder.DropTable(
                name: "T_OP_INSIGHT");

            migrationBuilder.DropTable(
                name: "T_OP_DADOS_CLIENTE");

            migrationBuilder.DropTable(
                name: "T_OP_USUARIO");
        }
    }
}
