using BlazorApp1.Server.Entities;
using System.Text.Json;

namespace BlazorApp1.Server.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        public CompanyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CompanyClient");
        }

        public async Task<(IEnumerable<CompanyDto>, MetaData)> GetCompanies(bool includeEmployees, int pageNumber, int pageSize)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Companies?includeEmployees={includeEmployees}&PageNumber={pageNumber}&PageSize={pageSize}");
            var response = await _httpClient.SendAsync(request);

            var header = response.Headers.TryGetValues("X-Pagination", out IEnumerable<string> values);
            var valueheader = values.FirstOrDefault();
            var paginationInfo = JsonSerializer.Deserialize<MetaData>(valueheader);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<CompanyDto>>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return (result, paginationInfo);
        }
    }
}
