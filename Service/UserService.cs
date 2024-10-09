using Entities.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {

            _repository = repository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _repository.GetUserByEmail(email);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                throw new Exception("Kullanıcı adı veya şifre yanlış");
            }

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("sub", user.UserId.ToString()),
                    new Claim("role", user.Role)  
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["TokenExpiryInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
           
        }

        public async Task RegisterAsync(string userName, string email, string password, string role = "Customer")
        {
           var existingUser = await _repository.GetUserByEmail(email);
            if (existingUser != null)
            {
                throw new NotImplementedException("Kullanıcı mevcut.");
            }
            var user = new User
            {
                Username = userName,
                Email = email,
                CreateDate = DateTime.UtcNow,
                Role = role
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            await _repository.AddUser(user);
        }
    }
}
