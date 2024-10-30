using PortfolioAcoes.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PortfolioAcoes.Domain.Entities;

public class Transacao
{
    [Required]
    public int Id { get; private set; }
    public string Ticker { get; private set; }
    public DateTime Data { get; private set; }
    public int TipoTransacaoId { get; private set; }
    public TipoTransacaoEntity Tipo { get; private set; } = null!;
    public int Quantidade { get; private set; }
    public decimal PrecoPorAcao { get; private set; }

#nullable disable
    public Transacao() { }
#nullable enable

    public Transacao(string ticker, DateTime data, int tipo, int quantidade, decimal precoPorAcao)
    {
        Ticker = ticker ?? throw new ArgumentNullException(nameof(ticker));
        Data = data;
        TipoTransacaoId = tipo;
        Quantidade = quantidade;
        PrecoPorAcao = precoPorAcao;
    }
}