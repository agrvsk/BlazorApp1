using System.Text.Json;
using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services;

public class RiddleService : IRiddleService
{
    private readonly HttpClient httpClient;

    public RiddleService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("RiddleClient");
    }

    public async Task<IEnumerable<Riddle>> GetRiddles()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"v1/riddles");
        var response = await httpClient.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<IEnumerable<Riddle>>(content);

        return result;
    }

}
