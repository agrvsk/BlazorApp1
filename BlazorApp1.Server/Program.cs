using BlazorApp1.Server.Components;
using BlazorApp1.Server.Components.Account;
using BlazorApp1.Server.Data;
using BlazorApp1.Server.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

        builder.Services.AddHttpClient("CatClient", client =>
        {
            client.BaseAddress = new Uri("https://api.api-ninjas.com");
            client.DefaultRequestHeaders.Add("X-Api-Key", "53jgXwKllLaKNQ1U4lLyiw==ktmA2BZNcvlzmmhe");
        });

        builder.Services.AddHttpClient("RiddleClient", client =>
        {
            client.BaseAddress = new Uri("https://api.api-ninjas.com");
            client.DefaultRequestHeaders.Add("X-Api-Key", "53jgXwKllLaKNQ1U4lLyiw==ktmA2BZNcvlzmmhe");
        });

        builder.Services.AddHttpClient("CompanyClient", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7273");
        });

        builder.Services.AddScoped<ICatService, CatService>();
        builder.Services.AddScoped<IRiddleService, RiddleService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();


        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        //builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        //{
        //    options.SignIn.RequireConfirmedAccount = true;
        //})
        //.AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
        builder.Services.AddScoped<IWaterService, WaterService>();
        builder.Services.AddScoped<ITodoService, TodoService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}
