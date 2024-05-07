using System.Net;
using Xunit;

namespace IntegrationTestProject.ControllerTests;

public class RainfallControllerTests : IDisposable
{
    private GeniuseeTestTaskApplicationFactory _applicationFactory;
    private HttpClient _httpClient;

    public RainfallControllerTests()
    {
        _applicationFactory = new GeniuseeTestTaskApplicationFactory();
        _httpClient = _applicationFactory.CreateClient();
    }

    public void Dispose()
    {
        _applicationFactory.Dispose();
        _httpClient.Dispose();
    }

    [Fact]
    public async Task GetReadingsSuccess()
    {
        var response = await _httpClient.GetAsync("/rainfall/id/52203/readings");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Dispose();
    }

    [Fact]
    public async Task GetReadingsNotFound()
    {
        var response = await _httpClient.GetAsync("/rainfall/id/randomId/readings");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Dispose();
    }

    [Fact]
    public async Task GetReadingsBadRequestId()
    {
        var response = await _httpClient.GetAsync("/rainfall/id/1/readings");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Dispose();
    }

    [Fact]
    public async Task GetReadingsBadRequestCount()
    {
        var response = await _httpClient.GetAsync("/rainfall/id/1/readings?count=-1");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Dispose();
    }
}