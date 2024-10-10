using Entities.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUserService
    {
        Task RegisterAsync(string user, string email, string password, string role);
        Task<Dictionary<string, string>> LoginAsync(string email, string password);
        Task<string> RefreshToken(string refreshToken);
        
    }
}
