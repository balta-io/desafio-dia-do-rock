using DesafioDiaDoRock.ApplicationCore.DTO.UserDTO;
using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<User>> GetListUsers();
        Task<User> Get(int? id);
        Task<User> Get(string email);
        Task<Response<User>> Create(RegisterDTO obj);
        Task<Response<dynamic>> Login(LoginDTO obj);
        Task<User> Update(User obj);
        Task<User> Remove(User obj);
    }
}
