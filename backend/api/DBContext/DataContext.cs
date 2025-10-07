using api.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace api.DBContext;

public class DataContext : DbContext
{
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.TraversePath().Load(".env");

        var connectionString = Environment.GetEnvironmentVariable("ConnectionString"); 
        
        optionsBuilder.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    }
    
    public DbSet<Postal> Postals { get; set; }
}