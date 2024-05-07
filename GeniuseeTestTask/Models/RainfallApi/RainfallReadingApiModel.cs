namespace GeniuseeTestTask.Models.RainfallApi;

public record RainfallReadingApiModel
{
    public DateTime DateTime { get; set; }
    public decimal Value { get; set; }
}