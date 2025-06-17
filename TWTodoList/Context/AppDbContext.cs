using Microsoft.EntityFrameworkCore;
using TWTodoList.EntityConfig;
using TWTodoList.Models;

namespace TWTodoList.Context;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoEntityConfig());
    }


}
