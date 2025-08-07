using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface IWaterService
    {
        Task DeleteIntake(int id);
        Task<List<Water>> GetIntakes();
        Task SaveIntake(Water intake);
        int GetTodaysIntake();
    }
}