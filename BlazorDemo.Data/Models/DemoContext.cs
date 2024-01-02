using BlazorDemo.Data.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorDemo.Data.Models;

public class DemoContext : DbContext
{ 
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DemoDB.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
