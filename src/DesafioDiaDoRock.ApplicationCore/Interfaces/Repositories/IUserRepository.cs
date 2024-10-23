using DesafioDiaDoRock.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetListUsers();
        Task<User> Get(int? id);
        Task<User> Get(string email);
        Task<User> Create(User obj);
        Task<User> Update(User obj);
        Task<User> Remove(User obj);
        Task<bool> AlredyExist(string email);
    }
}
