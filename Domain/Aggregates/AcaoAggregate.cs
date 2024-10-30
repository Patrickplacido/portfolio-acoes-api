using PortfolioAcoes.Domain.Entities;

namespace PortfolioAcoes.Domain.Aggregates;

public class AcaoAggregate
{
    private readonly Acao _acao;

    public AcaoAggregate(Acao acao)
    {
        _acao = acao ?? throw new ArgumentNullException(nameof(acao));
    }

    public Acao Acao => _acao;

    public void EfetuarCompra(int quantidade, decimal precoPorAcao)
    {
        if ( quantidade <= 0 ) throw new ArgumentException("Quantity must be greater than zero.");
        if ( precoPorAcao <= 0 ) throw new ArgumentException("Price per share must be greater than zero.");

        _acao.AddQuantidade(quantidade, precoPorAcao);
    }

    public void EfetuarVenda(int quantidade)
    {
        if ( quantidade <= 0 ) throw new ArgumentException("Quantity must be greater than zero.");
        if ( quantidade > _acao.Quantidade ) throw new InvalidOperationException("Not enough shares to sell.");

        _acao.RemoverQuantidade(quantidade);
    }

    public void ReceberDividendo(decimal valorDividendo)
    {
        if ( valorDividendo <= 0 ) throw new ArgumentException("Dividend amount must be greater than zero.");

        _acao.ReceberDividendo(valorDividendo);
    }

    public decimal CalculaLucroOuPerda(decimal precoAtualPorAcao)
    {
        if ( precoAtualPorAcao <= 0 ) throw new ArgumentException("Current price per share must be greater than zero.");

        var valorAtual = _acao.Quantidade * precoAtualPorAcao;
        return valorAtual - _acao.TotalInvestido;
    }
}
