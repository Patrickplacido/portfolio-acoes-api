using PortfolioAcoes.Domain.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using PortfolioAcoes.Application.Responses;

namespace PortfolioAcoes.Application.Services;

public class AlphaVantageService(HttpClient httpClient, IConfiguration configuration) : IAlphaVantageService
{
    private readonly string _apiKey = configuration["apiKey"]!;

    public async Task<decimal> GetPrecoAtualPorAcaoAsync(string ticker)
    {
        var url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={ticker}.sao&outputsize=full&apikey={_apiKey}";
        var response = await httpClient.GetStringAsync(url);

        var alphaVantageResponse = JsonConvert.DeserializeObject<AlphaVantageResponse>(response);

        if ( alphaVantageResponse?.TimeSeries == null || !alphaVantageResponse.TimeSeries.Any() )
        {
            throw new InvalidOperationException("Failed to retrieve stock data.");
        }

        // Obtendo a data mais recente
        var latestDate = alphaVantageResponse.TimeSeries.Keys.Max();
        var latestData = alphaVantageResponse.TimeSeries[latestDate!];

        return decimal.Parse(latestData.Close, CultureInfo.InvariantCulture);
    }
}