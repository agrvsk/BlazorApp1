using BlazorApp1.Client.Pages;
using BlazorApp1.Client.Services;
using BlazorApp1.Components;

namespace BlazorApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped(sp =>
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.api-ninjas.com")
            };

            // Lägg till en standardheader
            client.DefaultRequestHeaders.Add("X-Api-Key", "53jgXwKllLaKNQ1U4lLyiw==ktmA2BZNcvlzmmhe");

            //client.DefaultRequestHeaders.Authorization =
            //    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "din-jwt-token");

            return client;
        });


        builder.Services.AddSingleton<IGlobalStateVars, GlobalStateVars>();
        builder.Services.AddScoped<ICatService, CatService>();


        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

        //builder.Services.AddHttpClient("CatClient", client =>
        //{
        //    client.BaseAddress = new Uri("https://api.api-ninjas.com");
        //    client.DefaultRequestHeaders.Add("X-Api-Key", "53jgXwKllLaKNQ1U4lLyiw==ktmA2BZNcvlzmmhe");
        //});

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
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
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        app.Run();
    }
}
