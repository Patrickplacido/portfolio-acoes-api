using PortfolioAcoes.Domain.Entities;

namespace PortfolioAcoes.Domain.Repositories;

public interface IAcaoRepository
{
    Task<Acao?> GetAcaoAsync(string ticker, string userId);
    Task InsertAcaoAsync(Acao acao);
    Task<Dividendo?> GetDividendoAsync(int id);
    Task InsertDividendoAsync(Dividendo dividendo);
    Task InsertTransacaoAsync(Transacao transacao);
    Task<List<Acao>> GetAcoesAsync(string userId);
    Task<List<Dividendo>> GetDividendosAsync(string userId);
    Task<List<Transacao>> GetTransacoesAsync(string userId);
}
