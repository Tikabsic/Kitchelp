using Application.Authentication;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.LoginService;
using Application.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.LoginService
{
    internal class LoginServiceHelper : ILoginServiceHelper
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AuthSettings _authSettings;


        public LoginServiceHelper(IPasswordHasher passwordHasher,
                            IRepositoryFactory repositoryFactory,
                            AuthSettings authSettings)

        {
            _passwordHasher = passwordHasher;
            _repositoryFactory = repositoryFactory;
            _authSettings = authSettings;
        }

        public async Task<string> GenerateToken(UserLoginRequest request)
        {
            var repository = _repositoryFactory.Create<User>();

            var users = await repository.GetAllAsync();
            var user = users.First(x => x.Email == request.Email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                new Claim(ClaimTypes.Name, $"{user.LastName}"),
                new Claim(ClaimTypes.Email, $"{user.Email}"),
                new Claim(ClaimTypes.Role, $"{user.Role}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JWTKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authSettings.JWTExpireDays);
            var token = new JwtSecurityToken(_authSettings.JWTIssuer, _authSettings.JWTIssuer, claims, expires: expires, signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token).ToString();
        }

        public async Task<bool> VerifyPassword(UserLoginRequest request)
        {
            var repository = _repositoryFactory.Create<User>();

            var users = await repository.GetAllAsync();
            var user = users.First(x => x.Email == request.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var result = _passwordHasher.Verify(user.Password, request.Password);

            return result;
        }
    }
}
