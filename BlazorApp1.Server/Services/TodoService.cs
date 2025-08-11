using BlazorApp1.Server.Data;
using BlazorApp1.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services;

public class TodoService(ApplicationDbContext myContext) : ITodoService
{
    public async Task<List<Todo>> GetTodosAsync()
    {
        return await myContext.Todo.ToListAsync();
    }
    public async Task SaveTodoAsync(Todo dta)
    {
        myContext.Todo.Add(dta);
        await myContext.SaveChangesAsync();
    }

    public async Task UpdateTodoAsync(int id, Todo dta)
    {
        Todo org = myContext.Todo.SingleOrDefault(myContext.Todo.Single(x => x.Id == id));
        if (org != null)
        {
            org.Title = dta.Title;
            org.Description = dta.Description;
            org.AssignedTo = dta.AssignedTo;
            await myContext.SaveChangesAsync();
        }
        else throw new Exception($"Todo with id {id} was not found.");
    }


    public async Task DeleteTodoAsync(int id)
    {
        Todo org = myContext.Todo.SingleOrDefault(x => x.Id == id);
        if (org != null)
        {
            myContext.Todo.Remove(myContext.Todo.SingleOrDefault(x => x.Id == id));
            await myContext.SaveChangesAsync();
        }
        else
            Console.WriteLine($"Ingen rad med id {id} hittades.");
    }
}
