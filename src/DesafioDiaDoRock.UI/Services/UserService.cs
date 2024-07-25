﻿using DesafioDiaDoRock.ApplicationCore.DTO.UserDTO;
using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace DesafioDiaDoRock.UI.Services
{
    public class UserService(IHttpClientFactory httpClientFactory) : IUserService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<User>> Create(RegisterDTO obj)
        {
            var response = await _client.PostAsJsonAsync("user/register", obj);

            if(response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Response<User>>();
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(errorContent);
                JsonElement root = doc.RootElement;
                root.TryGetProperty("message", out JsonElement messageElement);
                string errorMessage = messageElement.GetString();
                return new Response<User>(null, (int)response.StatusCode, errorMessage);
            }

        }

        public Task<User> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetListUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<dynamic>> Login(LoginDTO userDTO)
        {
            var response = await _client.PostAsJsonAsync("user/login", userDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Response<dynamic>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(errorContent);
                JsonElement root = doc.RootElement;
                root.TryGetProperty("message", out JsonElement messageElement);
                string errorMessage = messageElement.GetString();
                return new Response<dynamic>(null, (int)response.StatusCode, errorMessage);
            }
        }

        public Task<User> Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}