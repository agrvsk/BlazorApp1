using BlazorApp1.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

namespace BlazorApp1.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
        
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
        


        //builder.Services.AddHttpClient();
        //builder.Services.AddHttpClient("CatClient", client =>
        //{
        //    client.BaseAddress = new Uri("https://api.api-ninjas.com");
        //    client.DefaultRequestHeaders.Add("X-Api-Key", "BerNpN0ASoHnAQFRJrZbzOmPzrPnEoltWf22zocf");
        //});

        builder.Services.AddSingleton<IGlobalStateVars, GlobalStateVars>();
        builder.Services.AddScoped<ICatService, CatService>();

        await builder.Build().RunAsync();
    }
}
