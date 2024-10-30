namespace PortfolioAcoes.Domain.Services;

public interface IAlphaVantageService
{
    Task<decimal> GetPrecoAtualPorAcaoAsync(string ticker);
}