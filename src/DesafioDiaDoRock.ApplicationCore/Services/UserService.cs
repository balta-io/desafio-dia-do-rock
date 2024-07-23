using DesafioDiaDoRock.ApplicationCore.DTO.UserDTO;
using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<Response<User>> Create(RegisterDTO userDTO)
        {
            if (userDTO.Password != userDTO.ConfirmPassword)
                return new(null, (int)HttpStatusCode.Conflict, "Password and Password Confirmation must be the same");

            var user = new User(new(userDTO.Name), (userDTO.Email), (userDTO.Password));

            if (await userRepository.AlredyExist(userDTO.Email))
                return new(null, (int)HttpStatusCode.Conflict, "User with the same email already registered");

            return new(await userRepository.Create(user));

        }

        public async Task<Response<dynamic>> Login(LoginDTO userDTO)
        {
            User user = await userRepository.Get(userDTO.Email);

            if (user?.Password != null && userDTO.Password == user.Password)
                return new Response<dynamic>(new
                {
                    token = TokenService.GenerateToken(user)
                });

            return new(null, (int)HttpStatusCode.BadRequest, "Invalid email or password");
        }
         
        public async Task<User> Get(int? id)
            => await userRepository.Get(id);

        public async Task<User> Get(string email)
            => await userRepository.Get(email);

        public async Task<List<User>> GetListUsers()
            => await userRepository.GetListUsers();

        public async Task<User> Remove(User user)
            => await userRepository.Remove(user);

        public async Task<User> Update(User user)
            => await userRepository.Update(user);
    }
}
