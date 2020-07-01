using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroProduto.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Basico = table.Column<string>(nullable: false),
                    Primario = table.Column<string>(nullable: false),
                    Secundario = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichaTecnicaLinha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnicaLinha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(maxLength: 20, nullable: false),
                    ConfirmacaoSenha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    FichaTecnicaLinhaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linha_FichaTecnicaLinha_FichaTecnicaLinhaId",
                        column: x => x.FichaTecnicaLinhaId,
                        principalTable: "FichaTecnicaLinha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    SubCategoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: false),
                    Cep = table.Column<string>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acessorio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Basico = table.Column<bool>(nullable: false),
                    LinhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acessorio_Linha_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaTecnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: true),
                    ComponenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaTecnica_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaTecnica_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    FichaTecnicaId = table.Column<int>(nullable: true),
                    LinhaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_FichaTecnica_FichaTecnicaId",
                        column: x => x.FichaTecnicaId,
                        principalTable: "FichaTecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Linha_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessorio_LinhaId",
                table: "Acessorio",
                column: "LinhaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_SubCategoriaId",
                table: "Categoria",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnica_CategoriaId",
                table: "FichaTecnica",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnica_ComponenteId",
                table: "FichaTecnica",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Linha_FichaTecnicaLinhaId",
                table: "Linha",
                column: "FichaTecnicaLinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ClienteId",
                table: "Produto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FichaTecnicaId",
                table: "Produto",
                column: "FichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_LinhaId",
                table: "Produto",
                column: "LinhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessorio");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "FichaTecnica");

            migrationBuilder.DropTable(
                name: "Linha");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "FichaTecnicaLinha");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
