using GeniuseeTestTask.Models.RainfallApi;

namespace GeniuseeTestTask.Models.Rainfall;

public class RainfallReading
{
    public DateTime DateMeasured { get; set; }
    public decimal AmountMeasured { get; set; }

    public RainfallReading() { }

    public RainfallReading(RainfallReadingApiModel rainfallApiResponse)
    {
        DateMeasured = rainfallApiResponse.DateTime;
        AmountMeasured = rainfallApiResponse.Value;
    }
}