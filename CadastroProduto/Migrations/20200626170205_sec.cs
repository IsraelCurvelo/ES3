using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroProduto.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaTecnica_Linha_LinhaId",
                table: "FichaTecnica");

            migrationBuilder.DropIndex(
                name: "IX_FichaTecnica_LinhaId",
                table: "FichaTecnica");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "FichaTecnica");

            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_LinhaId",
                table: "Produto",
                column: "LinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto",
                column: "LinhaId",
                principalTable: "Linha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_LinhaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "FichaTecnica",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnica_LinhaId",
                table: "FichaTecnica",
                column: "LinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaTecnica_Linha_LinhaId",
                table: "FichaTecnica",
                column: "LinhaId",
                principalTable: "Linha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
