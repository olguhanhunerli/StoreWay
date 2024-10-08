using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUserAdressService
    {
        Task<IEnumerable<UserAdressDto>> GetUserAdresses();
        Task UpdateUserAdresses(UpdateUserAdressDto userAdresses);
        Task AddUserAdress(UserAdress userAdress);
        Task RemoveUserAdress(int id);
        Task GetById(int id);
    }
}
