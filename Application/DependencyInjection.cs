using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.RegisterService;
using Application.MappingProfiles;
using Application.Middleware;
using Application.Services;
using Application.Services.RegisterService;
using Application.Validation.RegisterValidator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Validators scope
            services.AddScoped<IValidator<RegisterRequestDTO>, RegisterValidator>();

            //Services scope
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IRegisterServiceHelper, RegisterServiceHelper>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Automapper scope
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfilesConfiguration)));

            //Middlewares
            services.AddScoped<ExceptionHandlerMiddleware>();

            return services;
        }
    }
}
