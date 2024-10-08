using Entities.Models;
using Entities.Models.DTO;
using Repository.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserAdressService : IUserAdressService
    {
        private readonly IUserAdressRepository _repository;

        public UserAdressService(IUserAdressRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUserAdress(UserAdress userAdress)
        {
            await _repository.AddAsync(userAdress);
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserAdressDto>> GetUserAdresses()
        {
            var adress = await _repository.GetAllAsync();
            if (adress == null)
            {
                return new List<UserAdressDto>();
            }
            return adress.Select(p => new UserAdressDto
            {
                Id = p.Id,
                UserId = p.UserId,
                city = p.city,
                country = p.country,
                county = p.county,
                district = p.district,
                phone = p.phone,
                UserName = p.Users.Username,
                type = p.Type,
            }).ToList() ;
        }

        public Task RemoveUserAdress(int id)
        {
            throw new NotImplementedException();
        }

        public async Task  UpdateUserAdresses(UpdateUserAdressDto userAdresses)
        {
            var entity = await _repository.GetByIdAsync(userAdresses.Id);
            if (entity == null)
            {
                throw new ArgumentException($"Product with ID {entity.Id} not found.");
            }
            entity.county = userAdresses.county;
            entity.phone = userAdresses.phone; 
            entity.country = userAdresses.country;
            entity.district = userAdresses.district;
            entity.Type = userAdresses .type;

            await _repository.UpdateAsync(entity);  
            
        }
    }
}
