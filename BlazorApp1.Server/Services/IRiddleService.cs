using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface IRiddleService
    {
        Task<IEnumerable<Riddle>> GetRiddles();
    }
}