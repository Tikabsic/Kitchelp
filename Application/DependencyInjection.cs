using Application.DTOs;
using Application.Interfaces;
using Application.MappingProfiles;
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

            services.AddScoped<IValidator<RegisterRequestDTO>, RegisterValidator>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfilesConfiguration)));

            return services;
        }
    }
}
