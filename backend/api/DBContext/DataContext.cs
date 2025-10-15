using api.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace api.DBContext;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        Env.TraversePath().Load();

        var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    
    }

    public DataContext()
    {

    }

    public DbSet<Postal> Postals { get; set; }
}
