using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Services
{
    public interface ITodoService
    {
        Task DeleteTodoAsync(int id);
        Task<List<Todo>> GetTodosAsync();
        Task SaveTodoAsync(Todo dta);
        Task UpdateTodoAsync(int id, Todo dta);
    }
}