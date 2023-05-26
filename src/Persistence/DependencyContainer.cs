using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;

namespace Persistence;

public static class DependencyContainer
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ResourceDbContext>(options => options.UseNpgsql(GetConnectionString()));
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

        return services;
    }

    private static string GetConnectionString()
    {
        var host = Environment.GetEnvironmentVariable("DBHOST");
        var port = Environment.GetEnvironmentVariable("DBPORT");
        var user = Environment.GetEnvironmentVariable("DBUSER");
        var password = Environment.GetEnvironmentVariable("DBPASSWORD");
        var dbname = Environment.GetEnvironmentVariable("DBNAME");
        var connectionString = $"Username={user};Password={password};Host={host};Port={port};Database={dbname};";
        return connectionString;
    }
}
