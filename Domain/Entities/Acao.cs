using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PortfolioAcoes.Domain.Entities;

public class Acao
{
    [Required]
    public int Id { get; private set; }
    public string Ticker { get; private set; }
    public int Quantidade { get; private set; }
    public decimal TotalInvestido { get; private set; }
    public Acao(string ticker)
    {
        Ticker = ticker ?? throw new ArgumentNullException(nameof(ticker));
        Quantidade = 0;
        TotalInvestido = 0m;
    }

    public void AddQuantidade(int quantidade, decimal precoPorAcao)
    {
        if ( quantidade <= 0 ) throw new ArgumentException("Quantity must be greater than zero.");
        if ( precoPorAcao <= 0 ) throw new ArgumentException("Price per share must be greater than zero.");

        Quantidade += quantidade;
        TotalInvestido += quantidade * precoPorAcao;
    }

    public void RemoverQuantidade(int quantidade)
    {
        if ( quantidade <= 0 ) throw new ArgumentException("Quantity must be greater than zero.");
        if ( quantidade > Quantidade ) throw new InvalidOperationException("Not enough shares to sell.");

        var precoMedio = TotalInvestido / Quantidade;

        TotalInvestido -= quantidade * precoMedio;
        Quantidade -= quantidade;
    }

    public void ReceberDividendo(decimal valorDividendo)
    {
        if ( valorDividendo <= 0 ) throw new ArgumentException("Dividend amount must be greater than zero.");

        TotalInvestido -= valorDividendo;
    }
}
