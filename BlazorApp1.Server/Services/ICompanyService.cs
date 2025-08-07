using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface ICompanyService
    {
        Task<(IEnumerable<CompanyDto>, MetaData)> GetCompanies(bool includeEmployees, int pageNumber, int pageSize);
    }
}