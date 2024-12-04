using Microsoft.AspNetCore.Identity;
using PortfolioAcoes.Domain.Entities;

namespace PortfolioAcoes.Domain.Services;

public interface IAcaoService
{
    Task EfetuarCompraAsync(string ticker, int quantidade, decimal precoPorAcao, string userName);
    Task EfetuarVendaAsync(string ticker, int quantidade, decimal precoPorAcao, string userName);
    Task ReceberDividendoAsync(string ticker, decimal valorDividendo, string userName);
    Task<decimal> CalcularLucroOuPerda(string ticker, string userName);
    Task<List<Acao>> GetAcoes(string userName);
    Task<List<Dividendo>> GetDividendos(string userName);
    Task<List<Transacao>> GetTransacoes(string userName);
}
