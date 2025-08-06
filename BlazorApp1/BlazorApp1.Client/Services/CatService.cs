using BlazorApp1.Client.Entities;
using System.Text.Json;
using System.Net.Http;

namespace BlazorApp1.Client.Services;

public class CatService : ICatService
{
    private readonly HttpClient httpClient;

    //public CatService(IHttpClientFactory httpClientFactory)
    //{
    //    httpClient = httpClientFactory.CreateClient("CatClient");
    //}
    public CatService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Cat>> GetCats(string name)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"v1/cats?name={name}");
        var response = await httpClient.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<IEnumerable<Cat>>(content);

        return result;
    }


}
