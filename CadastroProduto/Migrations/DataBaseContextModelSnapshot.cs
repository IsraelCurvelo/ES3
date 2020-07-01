﻿// <auto-generated />
using System;
using CadastroProduto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroProduto.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CadastroProduto.Models.Domain.Acessorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Basico");

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("LinhaId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Quantidade");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId")
                        .IsUnique();

                    b.ToTable("Acessorio");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("SubCategoriaId");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("EstadoId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Basico")
                        .IsRequired();

                    b.Property<string>("Primario")
                        .IsRequired();

                    b.Property<string>("Secundario")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("Cep")
                        .IsRequired();

                    b.Property<int?>("CidadeId");

                    b.Property<string>("Complemento");

                    b.Property<string>("Logradouro")
                        .IsRequired();

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.FichaTecnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoriaId");

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<int?>("ComponenteId");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Observacoes");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ComponenteId");

                    b.ToTable("FichaTecnica");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.FichaTecnicaLinha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("FichaTecnicaLinha");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Linha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<int?>("FichaTecnicaLinhaId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FichaTecnicaLinhaId");

                    b.ToTable("Linha");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<DateTime>("DataEntrada");

                    b.Property<int?>("FichaTecnicaId");

                    b.Property<int?>("LinhaId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Quantidade");

                    b.Property<bool>("Status");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FichaTecnicaId");

                    b.HasIndex("LinhaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.SubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SubCategoria");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmacaoSenha")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CadastroProduto.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Acessorio", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.Linha", "Linha")
                        .WithOne("Acessorio")
                        .HasForeignKey("CadastroProduto.Models.Domain.Acessorio", "LinhaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Categoria", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.SubCategoria", "SubCategoria")
                        .WithMany()
                        .HasForeignKey("SubCategoriaId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Cidade", b =>
                {
                    b.HasOne("CadastroProduto.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Cliente", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Endereco", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.FichaTecnica", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("CadastroProduto.Models.Domain.Componente", "Componente")
                        .WithMany()
                        .HasForeignKey("ComponenteId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Linha", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.FichaTecnicaLinha", "FichaTecnicaLinha")
                        .WithMany()
                        .HasForeignKey("FichaTecnicaLinhaId");
                });

            modelBuilder.Entity("CadastroProduto.Models.Domain.Produto", b =>
                {
                    b.HasOne("CadastroProduto.Models.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("CadastroProduto.Models.Domain.FichaTecnica", "FichaTecnica")
                        .WithMany()
                        .HasForeignKey("FichaTecnicaId");

                    b.HasOne("CadastroProduto.Models.Domain.Linha", "Linha")
                        .WithMany()
                        .HasForeignKey("LinhaId");
                });
#pragma warning restore 612, 618
        }
    }
}
