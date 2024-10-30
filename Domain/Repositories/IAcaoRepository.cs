using PortfolioAcoes.Domain.Entities;

namespace PortfolioAcoes.Domain.Repositories;

public interface IAcaoRepository
{
    Task<Acao?> GetAcaoAsync(string ticker);
    Task InsertAcaoAsync(Acao acao);
    Task<Dividendo?> GetDividendoAsync(int id);
    Task InsertDividendoAsync(Dividendo dividendo);
    Task InsertTransacaoAsync(Transacao transacao);
    Task<List<Acao>> GetAcoesAsync();
    Task<List<Dividendo>> GetDividendosAsync();
    Task<List<Transacao>> GetTransacoesAsync();
}
