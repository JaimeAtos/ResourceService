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
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ResourceDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

        return services;
    }
}
