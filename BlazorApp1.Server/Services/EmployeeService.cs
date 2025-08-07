using BlazorApp1.Server.Entities;
using System.Text.Json;

namespace BlazorApp1.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("CompanyClient");

        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees(int companyId)
        {
            await Task.Delay(1000);
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/companies/{companyId}/employees");
            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<EmployeeDto>>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return result;
        }
    }
}
