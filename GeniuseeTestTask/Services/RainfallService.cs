using GeniuseeTestTask.Interfaces;
using GeniuseeTestTask.Models.Rainfall;
using GeniuseeTestTask.Models.RainfallApi;

namespace GeniuseeTestTask.Services;

public class RainfallService(IRainfallApiService rainfallApiService) : IRainfallService
{
    public async Task<IEnumerable<RainfallReading>> GetStationReadings(string stationId, int count)
    {
        var parameters = new Dictionary<string, object>
        {
            { "_limit", count }
        };
        var stationReadings =
            await rainfallApiService.Get<RainfallApiResponse>(
                $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings",
                parameters);

        return stationReadings!.Items.AsParallel().Select(item => new RainfallReading(item));
    }
}