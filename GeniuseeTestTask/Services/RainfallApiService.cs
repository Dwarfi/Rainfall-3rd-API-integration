using System.Text.Json;
using System.Web;
using GeniuseeTestTask.Interfaces;

namespace GeniuseeTestTask.Services;

public class RainfallApiService(IHttpClientFactory httpClientFactory) : IRainfallApiService
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<T?> Get<T>(string uri, Dictionary<string, object>? parameters = null)
    {
        var httpClient = httpClientFactory.CreateClient();
        
        if (parameters is not null) uri = BuildQueriedUri(uri, parameters);

        var stream = await httpClient.GetStreamAsync(uri);

        return await JsonSerializer.DeserializeAsync<T>(stream, _options);
    }

    /*
     Other REST HTTP methods to be implemented
     */

    private static string BuildQueriedUri(string uri, Dictionary<string, object> parameters)
    {
        var builder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(builder.Query);

        foreach (var param in parameters) 
            query[param.Key] = param.Value.ToString();
        
        builder.Query = query.ToString();

        return builder.ToString();
    }
}