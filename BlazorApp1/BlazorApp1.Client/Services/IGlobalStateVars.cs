using BlazorApp1.Client.Components;
using BlazorApp1.Client.Entities;

namespace BlazorApp1.Client.Services
{
    public interface IGlobalStateVars
    {
        List<ProduktComponent.Usermodel> MyProduktlist { get; }
        List<Todo> MyToDolist { get; } 

        string MittNamn { get; set; }


        event Action? OnChange;

        void AddProdukt(ProduktComponent.Usermodel prod);
        void AngeNamn(string nn);
    }
}