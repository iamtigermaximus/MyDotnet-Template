using System;
using dotnet_template2023.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_template2023.Data;

public class DataContext:DbContext
{
    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Employee> Employees { get; set; }

}

