using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAcoes.Infrastructure.Migrations
{
    public partial class AdicionandoTabelaEnumTransacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Transacoes",
                newName: "TipoTransacaoId");

            migrationBuilder.CreateTable(
                name: "TipoTransacaoEnums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacaoEnums", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_TipoTransacaoEnums_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacaoEnums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_TipoTransacaoEnums_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "TipoTransacaoEnums");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "TipoTransacaoId",
                table: "Transacoes",
                newName: "Tipo");
        }
    }
}
