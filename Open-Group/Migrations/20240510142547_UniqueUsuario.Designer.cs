﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Open_Group.Persistencia;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Open_Group.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20240510142547_UniqueUsuario")]
    partial class UniqueUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Open_Group.Models.Arquivo", b =>
                {
                    b.Property<int>("IdArquivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_ARQUIVO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArquivo"));

                    b.Property<int>("DadosClienteId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DADOS_ARQUIVO");

                    b.Property<DateTime>("DataUpload")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_UPLOAD");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("PalavraChave")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("PALAVRA_CHAVE");

                    b.Property<string>("Resumo")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<long>("Tamanho")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("IdArquivo");

                    b.HasIndex("DadosClienteId");

                    b.ToTable("T_OP_ARQUIVO");
                });

            modelBuilder.Entity("Open_Group.Models.DadosCliente", b =>
                {
                    b.Property<int>("IdDados")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_DADOS");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDados"));

                    b.Property<string>("CanalVenda")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("CANAL_VENDA");

                    b.Property<string>("Concorrente")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Desafio")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<float?>("FaturamentoAnual")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("FATURAMENTO_ANUAL");

                    b.Property<string>("Localizacao")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<int?>("NumFuncionarios")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("NUM_FUNCIONARIOS");

                    b.Property<string>("Objetivo")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Porte")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("ProdutoServico")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("PRODUTO_SERVICO");

                    b.Property<string>("Segmento")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int?>("TempoAtuacao")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("TEMPO_ATUACAO");

                    b.Property<string>("Tipo")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("USUARIO_DADOS");

                    b.HasKey("IdDados");

                    b.HasIndex("UsuarioId");

                    b.ToTable("T_OP_DADOS_CLIENTE");
                });

            modelBuilder.Entity("Open_Group.Models.Insight", b =>
                {
                    b.Property<int>("IdInsight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_INSIGHT");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsight"));

                    b.Property<int>("DadosClienteId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DADOS_INSIGHT");

                    b.Property<DateTime>("DataGeracao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_GERACAO");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<int>("Impacto")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Recomendacao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.HasKey("IdInsight");

                    b.HasIndex("DadosClienteId");

                    b.ToTable("T_OP_INSIGHT");
                });

            modelBuilder.Entity("Open_Group.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_USUARIO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_CRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Identificacao")
                        .IsUnique();

                    b.ToTable("T_OP_USUARIO");
                });

            modelBuilder.Entity("Open_Group.Models.Arquivo", b =>
                {
                    b.HasOne("Open_Group.Models.DadosCliente", "DadosCliente")
                        .WithMany()
                        .HasForeignKey("DadosClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosCliente");
                });

            modelBuilder.Entity("Open_Group.Models.DadosCliente", b =>
                {
                    b.HasOne("Open_Group.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Open_Group.Models.Insight", b =>
                {
                    b.HasOne("Open_Group.Models.DadosCliente", "DadosCliente")
                        .WithMany()
                        .HasForeignKey("DadosClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosCliente");
                });
#pragma warning restore 612, 618
        }
    }
}
