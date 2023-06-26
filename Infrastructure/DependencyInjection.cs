using Application.Interfaces;
using Application.Interfaces.Repository;
using Domain.Entities;
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
        //dbContext config and scope
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase")));

        services.AddScoped<IAppDbContext, AppDbContext>();



        //Repository scope
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        services.AddScoped<IRepository<Restaurant>>(provider =>
            new Repository<Restaurant>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<User>>(provider =>
            new Repository<User>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<Owner>>(provider =>
            new Repository<Owner>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<Employee>>(provider =>
            new Repository<Employee>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<RestaurantEmployee>>(provider =>
            new Repository<RestaurantEmployee>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<Chat>>(provider =>
            new Repository<Chat>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<ChatMessage>>(provider =>
            new Repository<ChatMessage>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<WorkingDay>>(provider =>
            new Repository<WorkingDay>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<ShoppingList>>(provider =>
            new Repository<ShoppingList>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<ShoppingListProduct>>(provider =>
            new Repository<ShoppingListProduct>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<Product>>(provider =>
            new Repository<Product>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<Warehouse>>(provider =>
            new Repository<Warehouse>(provider.GetService<AppDbContext>()));

        services.AddScoped<IRepository<InvitationToken>>(provider =>
            new Repository<InvitationToken>(provider.GetService<AppDbContext>()));

        //Logger scope
        services.AddScoped<ILoggingHandler, LoggingHandler>();

        return services;
    }
}
