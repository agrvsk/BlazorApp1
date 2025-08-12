using BlazorApp1.Server.Entities;
using Microsoft.Identity.Client;

namespace BlazorApp1.Server.Components.Pages;

public partial class CompanyList
{
    private IEnumerable<CompanyDto> Companies { get; set; }
    public MetaData PagingData { get; set; }
    public bool PrevState { get; set; }
    public bool NextState { get; set; }

    public string PrevClass { get; set; }
    public string NextClass { get; set; }
    public bool Loading { get; set; } = false;

    private int pgNr = 1;
    private int pageSize = 5;
    private bool includeEmployees = false;

    protected override async Task OnInitializedAsync()
    {
        Loading = true;
        (Companies, PagingData) = await companyService.GetCompanies(includeEmployees, pgNr, pageSize);
        Loading = false;
        PrevState = !PagingData.HasPrevious;
        NextState = !PagingData.HasNext; 
        PrevClass = PagingData.HasPrevious  ? "btn-primary" : "btn-secondary";
        NextClass = PagingData.HasNext      ? "btn-primary" : "btn-secondary";
    }


    public async Task Previous()
    {
        pgNr--;
        Loading = true;
        (Companies, PagingData) = await companyService.GetCompanies(includeEmployees, pgNr, pageSize);
        Loading = false;
        PrevState = !PagingData.HasPrevious;
        NextState = !PagingData.HasNext;
        PrevClass = PagingData.HasPrevious    ? "btn-primary" : "btn-secondary";
        NextClass = PagingData.HasNext        ? "btn-primary" : "btn-secondary";
    }

    public async Task Next()
    {
        pgNr++;
        Loading = true;
        (Companies, PagingData) = await companyService.GetCompanies(includeEmployees, pgNr, pageSize);
        Loading = false;
        PrevState = !PagingData.HasPrevious;
        NextState = !PagingData.HasNext;
        PrevClass = PagingData.HasPrevious  ? "btn-primary" : "btn-secondary";
        NextClass = PagingData.HasNext      ? "btn-primary" : "btn-secondary";
    }


}