using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface ICatService
    {
        Task<IEnumerable<Cat>> GetCats(string name);
    }
}