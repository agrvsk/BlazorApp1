using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Components.Pages
{
    public partial class CompanyList
    {
        private IEnumerable<CompanyDto> Companies { get; set; }
        public MetaData PagingData { get; set; }
        public bool Loading { get; set; } = false;

        private int companyId = 1;
        private int pageSize = 5;
        private bool includeEmployees = false;

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            (Companies, PagingData) = await companyService.GetCompanies(includeEmployees, companyId, pageSize);
            Loading = false;
        }

    }
}