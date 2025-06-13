using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using ServiceLib.Models;


namespace ServiceLib.Services
{
    public class ReqresClient
    {
        private readonly HttpClient _httpClient;

        public ReqresClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public async Task<User?> GetUserAsync(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<User>($"users/{id}");
        //}
        public async Task<UserListResponse?> GetUsersAsync(int page = 1)
        {
            return await _httpClient.GetFromJsonAsync<UserListResponse>($"users?page={page}");
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<SingleUserResponse>($"users/{id}");
            return response?.Data;
        }



        public async Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("users", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CreateUserResponse>();
        }
    }
}
