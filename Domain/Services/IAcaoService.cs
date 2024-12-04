using Microsoft.AspNetCore.Identity;
using PortfolioAcoes.Domain.Entities;

namespace PortfolioAcoes.Domain.Services;

public interface IAcaoService
{
    Task EfetuarCompraAsync(string ticker, int quantidade, decimal precoPorAcao);
    Task EfetuarVendaAsync(string ticker, int quantidade, decimal precoPorAcao);
    Task ReceberDividendoAsync(string ticker, decimal valorDividendo);
    Task<decimal> CalcularLucroOuPerda(string ticker);
    Task<List<Acao>> GetAcoes();
    Task<List<Dividendo>> GetDividendos();
    Task<List<Transacao>> GetTransacoes();
}
