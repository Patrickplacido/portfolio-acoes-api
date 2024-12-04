using PortfolioAcoes.Domain.Entities;
using PortfolioAcoes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PortfolioAcoes.Infrastructure.Repositories;

public class AcaoRepository : IAcaoRepository
{
    private readonly AcaoDbContext _acaoDbContext;

    public AcaoRepository(AcaoDbContext context)
    {
        _acaoDbContext = context;
    }
    public async Task<Acao?> GetAcaoAsync(string ticker, string userId)
    {
        var acao = await _acaoDbContext.Acoes
            .Where(a => a.Ticker == ticker && a.UserId == userId)
            .Select(a => a)
            .FirstOrDefaultAsync();

        return acao;
    }
    
    public async Task InsertAcaoAsync(Acao acao)
    {
        var acaoExistente = await _acaoDbContext.Acoes
            .SingleOrDefaultAsync(s => s.Ticker == acao.Ticker);

        if ( acaoExistente == null )
        {
            _acaoDbContext.Acoes.Add(acao);
        }
        else
        {
            _acaoDbContext.Entry(acaoExistente).CurrentValues.SetValues(acao);
        }

        await _acaoDbContext.SaveChangesAsync();
    }

    public async Task<Dividendo?> GetDividendoAsync(int id)
    {
        var dividendo = await _acaoDbContext.Dividendos.FindAsync(id);

        if (dividendo == null) throw new Exception("Dividendo não encontrado");
        else return dividendo;
    }

    public async Task InsertDividendoAsync(Dividendo dividendo)
    {
        var dividendoExistente = await _acaoDbContext.Dividendos
            .FindAsync(dividendo.Id);

        if ( dividendoExistente == null )
        {
            _acaoDbContext.Dividendos.Add(dividendo);
        }
        else
        {
            _acaoDbContext.Entry(dividendoExistente).CurrentValues.SetValues(dividendo);
        }

        await _acaoDbContext.SaveChangesAsync();
    }

    public async Task InsertTransacaoAsync(Transacao transacao)
    {
        _acaoDbContext.Transacoes.Add(transacao);        

        await _acaoDbContext.SaveChangesAsync();
    }

    public async Task<List<Acao>> GetAcoesAsync(string userId)
    {
        return await _acaoDbContext.Acoes.Where(u => u.UserId == userId).ToListAsync();
    }

    public async Task<List<Dividendo>> GetDividendosAsync(string userId)
    {
        return await _acaoDbContext.Dividendos.Where(u => u.UserId == userId).ToListAsync();
    }

    public async Task<List<Transacao>> GetTransacoesAsync(string userId)
    {
        return await _acaoDbContext.Transacoes.Where(u => u.UserId == userId).ToListAsync();
    }
}
