using System.ComponentModel.DataAnnotations;

namespace PortfolioAcoes.Domain.Entities;

public class Dividendo
{
    [Required]
    public int Id { get; private set; }
    public string Ticker { get; private set; }
    public DateTime Data { get; private set; }
    public decimal ValorDividendo { get; private set; }

    public Dividendo(string ticker, DateTime data, decimal valorDividendo)
    {
        Ticker = ticker ?? throw new ArgumentNullException(nameof(ticker));
        Data = data;
        ValorDividendo = valorDividendo;
    }
}
