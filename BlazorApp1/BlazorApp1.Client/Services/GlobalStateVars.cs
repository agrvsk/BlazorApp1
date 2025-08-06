using static BlazorApp1.Client.Components.ProduktComponent;

namespace BlazorApp1.Client.Services;

public class GlobalStateVars : IGlobalStateVars
{
    public List<Usermodel> MyProduktlist { get; set; } = new();
    public string MittNamn { get; set; } = "";

    public void AddProdukt(Usermodel prod)
    {
        MyProduktlist.Add(prod);
        NotifyStateChanged();
        Console.WriteLine("Produkt har lagts till i listan.");
    }
    public void AngeNamn(string nn)
    {
        MittNamn = nn;
        NotifyStateChanged();
        Console.WriteLine("Namnet har ändrats.");
    }

    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

}

