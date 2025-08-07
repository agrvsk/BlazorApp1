using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(int companyId);
    }
}