namespace GeniuseeTestTask.Interfaces;

public interface IRainfallApiService
{
    Task<T?> Get<T>(string uri, Dictionary<string, object>? parameters = null);
}