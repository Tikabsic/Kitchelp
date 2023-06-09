using Application.Interfaces;
using Infrastructure.Logging;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase")));

        //Repository scope
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));

        //Logger scope
        services.AddScoped<ILoggingHandler, LoggingHandler>();

        return services;
    }
}
