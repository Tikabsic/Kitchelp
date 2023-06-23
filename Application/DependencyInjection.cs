using Application.Authentication;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.LoginService;
using Application.Interfaces.RegisterService;
using Application.MappingProfiles;
using Application.Middleware;
using Application.Services;
using Application.Services.LoginService;
using Application.Services.RegisterService;
using Application.Validation.RegisterValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Interfaces.OwnerService;
using Application.Services.OwnerService;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Auth
            var authenticationSettings = new AuthSettings();

            configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddScoped<AuthSettings>(provider => authenticationSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JWTIssuer,
                    ValidAudience = authenticationSettings.JWTIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JWTKey)),
                };
            });

                //Validators scope
                services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();

            //Services scope
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IRegisterServiceHelper, RegisterServiceHelper>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginServiceHelper, LoginServiceHelper>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerServiceHelper, OwnerServiceHelper>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Automapper scope
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfilesConfiguration)));

            //Middlewares
            services.AddScoped<ErrorHandligMiddleware>();

            return services;
        }
    }
}
