using BlazorApp1.Client.Components;

namespace BlazorApp1.Client.Services
{
    public interface IGlobalStateVars
    {
        List<ProduktComponent.Usermodel> MyProduktlist { get; set; }
        public string MittNamn { get; set; }


        event Action? OnChange;

        void AddProdukt(ProduktComponent.Usermodel prod);
        public void AngeNamn(string nn);
    }
}