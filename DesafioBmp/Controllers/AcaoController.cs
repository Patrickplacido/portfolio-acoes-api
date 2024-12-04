using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioAcoes.Domain.Services;

namespace PortfolioAcoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AcaoController : ControllerBase
{
    private readonly IAcaoService _acaoService;

    public AcaoController(IAcaoService acaoService)
    {
        _acaoService = acaoService;
    }

    [HttpPost("compra")]
    public async Task<IActionResult> ComprarAcao([FromQuery] string ticker, [FromQuery] int quantidade, [FromQuery] decimal precoPorAcao)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _acaoService.EfetuarCompraAsync(ticker, quantidade, precoPorAcao);
        return Ok();
    }

    [HttpPost("venda")]
    public async Task<IActionResult> VenderAcao([FromQuery] string ticker, [FromQuery] int quantidade, [FromQuery] decimal precoPorAcao)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _acaoService.EfetuarVendaAsync(ticker, quantidade, precoPorAcao);
        return Ok();
    }

    [HttpPost("dividendo")]
    public async Task<IActionResult> ReceberDividendo([FromQuery] string ticker, [FromQuery] decimal valorDividendo)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _acaoService.ReceberDividendoAsync(ticker, valorDividendo);
        return Ok();
    }

    [HttpGet("lucro-ou-perda")]
    public async Task<IActionResult> CalcularLucroOuPerda([FromQuery] string ticker)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var perdaOuGanho = await _acaoService.CalcularLucroOuPerda(ticker);
        return Ok(perdaOuGanho);
    }

    [HttpGet("acoes")]
    public async Task<IActionResult> GetAcoes()
    {
        var acoes = await _acaoService.GetAcoes();
        return Ok(acoes);
    }

    [HttpGet("dividendos")]
    public async Task<IActionResult> GetDividendos()
    {
        var dividendos = await _acaoService.GetDividendos();
        return Ok(dividendos);
    }

    [HttpGet("transacoes")]
    public async Task<IActionResult> GetTransacoes()
    {
        var transacoes = await _acaoService.GetTransacoes();
        return Ok(transacoes);
    }
}
