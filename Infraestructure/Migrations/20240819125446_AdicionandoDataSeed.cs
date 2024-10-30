using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAcoes.Infrastructure.Migrations
{
    public partial class AdicionandoDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoTransacaoEnums",
                columns: new[] { "Id", "Descricao", "Tipo" },
                values: new object[] { 1, "Compra", 1 });

            migrationBuilder.InsertData(
                table: "TipoTransacaoEnums",
                columns: new[] { "Id", "Descricao", "Tipo" },
                values: new object[] { 2, "Venda", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoTransacaoEnums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoTransacaoEnums",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
