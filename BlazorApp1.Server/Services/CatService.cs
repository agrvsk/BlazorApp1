using BlazorApp1.Server.Entities;
using System.Text.Json;

namespace BlazorApp1.Server.Services
{
    public class CatService : ICatService
    {
        private readonly HttpClient httpClient;

        public CatService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("CatClient");
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
}
