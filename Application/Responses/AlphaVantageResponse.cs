using Newtonsoft.Json;

namespace PortfolioAcoes.Application.Responses;

public class AlphaVantageResponse
{
    [JsonProperty("Meta Data")]
    public MetaData MetaData { get; set; } = null!;

    [JsonProperty("Time Series (Daily)")]
    public Dictionary<string, DailyTimeSeries> TimeSeries { get; set; } = null!;
}

public class MetaData
{
    [JsonProperty("2. Symbol")]
    public string Symbol { get; set; } = null!;
}

public class DailyTimeSeries
{
    [JsonProperty("4. close")]
    public string Close { get; set; } = null!;
}