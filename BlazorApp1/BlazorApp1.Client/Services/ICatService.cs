using BlazorApp1.Client.Entities;

namespace BlazorApp1.Client.Services
{
    public interface ICatService
    {
        Task<IEnumerable<Cat>> GetCats(string name);
    }
}