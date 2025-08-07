using BlazorApp1.Server.Entities;
using BlazorApp1.Server.Services;

namespace BlazorApp1.Server.Components.Pages
{
    public partial class EmployeeRegister
    {
        private IEnumerable<EmployeeDto> Employees { get; set; }
        public bool Loading { get; set; } = false;

        private int companyId = 1;

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            Employees = await employeeService.GetEmployees(companyId);
            Loading = false;
        }

    }
}