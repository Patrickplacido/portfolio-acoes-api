using PortfolioAcoes.Domain.Aggregates;
using PortfolioAcoes.Domain.Entities;
using PortfolioAcoes.Domain.Enums;
using PortfolioAcoes.Domain.Repositories;
using PortfolioAcoes.Domain.Services;

namespace PortfolioAcoes.Application.Services
{
    public class AcaoService : IAcaoService
    {
        private readonly IAlphaVantageService _alphaVantageService;
        private readonly IAcaoRepository _acaoRepository;

        public AcaoService
        (
            IAlphaVantageService alphaVantageService, 
            IAcaoRepository acaoRepository
        )
        {
            _alphaVantageService = alphaVantageService;
            _acaoRepository = acaoRepository;
        }

        public async Task EfetuarCompraAsync(string ticker, int quantidade, decimal precoPorAcao)
        {
            var acao = await _acaoRepository.GetAcaoAsync(ticker);

            if ( acao == null )
            {
                acao = new Acao(ticker);
            }

            var acaoAggregate = new AcaoAggregate(acao);
            acaoAggregate.EfetuarCompra(quantidade, precoPorAcao);

            await _acaoRepository.InsertAcaoAsync(acao);

            var transacao = new Transacao(ticker, DateTime.UtcNow, (int)TipoTransacaoEnum.Compra, quantidade, precoPorAcao);

            await _acaoRepository.InsertTransacaoAsync(transacao);
        }

        public async Task EfetuarVendaAsync(string ticker, int quantidade, decimal precoPorAcao)
        {
            var acao = await _acaoRepository.GetAcaoAsync(ticker);
            if ( acao == null ) throw new InvalidOperationException("Stock not found.");

            var acaoAggregate = new AcaoAggregate(acao);
            acaoAggregate.EfetuarVenda(quantidade);

            await _acaoRepository.InsertAcaoAsync(acao);

            var transacao = new Transacao(ticker, DateTime.UtcNow, (int)TipoTransacaoEnum.Venda, quantidade, precoPorAcao);
            await _acaoRepository.InsertTransacaoAsync(transacao);
        }

        public async Task ReceberDividendoAsync(string ticker, decimal valorDividendo)
        {
            var acao = await _acaoRepository.GetAcaoAsync(ticker);
            if ( acao == null ) throw new InvalidOperationException("Stock not found.");

            var acaoAggregate = new AcaoAggregate(acao);
            acaoAggregate.ReceberDividendo(valorDividendo);

            await _acaoRepository.InsertAcaoAsync(acao);

            var dividendo = new Dividendo(ticker, DateTime.UtcNow, valorDividendo);
            await _acaoRepository.InsertDividendoAsync(dividendo);
        }

        public async Task<decimal> CalcularLucroOuPerda(string ticker)
        {
            var acao = await _acaoRepository.GetAcaoAsync(ticker);
            if ( acao == null ) throw new InvalidOperationException("Stock not found.");

            var precoAtualPorAcao = await _alphaVantageService.GetPrecoAtualPorAcaoAsync(ticker);

            var acaoAggregate = new AcaoAggregate(acao);
            return acaoAggregate.CalculaLucroOuPerda(precoAtualPorAcao);
        }

        public Task<List<Acao>> GetAcoes()
        {
            return _acaoRepository.GetAcoesAsync();
        }

        public Task<List<Dividendo>> GetDividendos()
        {
            return _acaoRepository.GetDividendosAsync();
        }

        public Task<List<Transacao>> GetTransacoes()
        {
            return _acaoRepository.GetTransacoesAsync();
        }
    }
}
