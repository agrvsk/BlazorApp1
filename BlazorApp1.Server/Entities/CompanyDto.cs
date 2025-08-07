using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Server.Entities
{
    public record CompanyDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        // public string? Country { get; init; }

        public IEnumerable<EmployeeDto> Employees { get; init; }
    }
}
