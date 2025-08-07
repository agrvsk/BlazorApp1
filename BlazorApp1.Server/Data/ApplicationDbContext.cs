using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //{
    //}

    public DbSet<Todo> Todo { get; set; } = default!;



}



