using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.Infraestructure.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<User> Create(User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> AlredyExist(string email)
            => await context.Set<User>().AnyAsync(x => x.Email == email);

        public async Task<User> Get(int? id)
        {
            return await context.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Get(string email)
        {
            return await context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetListUsers()
        {
            return await context.Set<User>().ToListAsync();
        }

        public async Task<User> Remove(User user)
        {
            context.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            context.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
