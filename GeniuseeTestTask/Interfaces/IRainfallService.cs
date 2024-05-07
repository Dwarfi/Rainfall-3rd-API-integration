using GeniuseeTestTask.Models.Rainfall;

namespace GeniuseeTestTask.Interfaces;

public interface IRainfallService
{
    Task<IEnumerable<RainfallReading>> GetStationReadings(string stationId, int count);
}