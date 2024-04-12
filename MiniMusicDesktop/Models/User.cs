using Microsoft.CodeAnalysis.CSharp.Syntax;
using MiniMusicDesktop.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniMusicDesktop.Models
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
        public InfoTypeEnum InfoTypes { get; set; } = InfoTypeEnum.User;
        public LoginStateEnum LoginSuccess { get; set; } = LoginStateEnum.Remove;
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("profilePictureUrl")]
        public string? ProfilePictureUrl { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        public static async Task<User> LoginAsync(string userId, string password)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");

                var data = new { UserId = userId, Password = password };
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var resData = await s_httpClient.PostAsync("UserLogin", content);
                try
                {
                    resData.EnsureSuccessStatusCode();
                    string stringResponse = await resData.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<User>(stringResponse);
                    searchResults!.LoginSuccess = LoginStateEnum.Login;
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("user login error");
                    return new User 
                    { Id = -1, UserId = userId, Password = password, InfoTypes = InfoTypeEnum.NullUser, LoginSuccess = LoginStateEnum.Remove };
                }
            }
            
        }


        public static async Task<User> RegisterAsync(string userId, string password,
            string? email, string? phone, string? profilePictureUrl, string? name)
        {

            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");
                var data = new
                {
                    UserId = userId,
                    Password = password,
                    Email = email,
                    Phone = phone,
                    ProfilePictureUrl = profilePictureUrl,
                    Name = name ?? "null_name"
                };
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var resData = await s_httpClient.PostAsync("UserRegister", content);
                try
                {
                    resData.EnsureSuccessStatusCode();
                    string stringResponse = await resData.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<User>(stringResponse);

                    return searchResults!;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("user Register error");
                    return new User { Id = -1, Password = "password", InfoTypes = InfoTypeEnum.NullUser, LoginSuccess = LoginStateEnum.Remove };
                }
            }

        }

        public static async Task<User> UpdateInfoAsync(string userId, 
            string oldPassword,
            string changePassword,
            string? email, string? phone, string? profilePictureUrl, string? name)
        {

            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");
                var data = new
                {
                    UserId = userId,
                    OldPassword = oldPassword,
                    ChangePassword = changePassword,
                    Email = email,
                    Phone = phone,
                    ProfilePictureUrl = profilePictureUrl,
                    Name = name ?? "null_name"
                };
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var resData = await s_httpClient.PostAsync("UserInfoUpdate", content);
                try
                {
                    resData.EnsureSuccessStatusCode();
                    string stringResponse = await resData.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<User>(stringResponse);

                    return searchResults!;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("user information update error");
                    return new User { Id = -1, Password = "password", InfoTypes = InfoTypeEnum.NullUser, LoginSuccess = LoginStateEnum.Remove };
                }
            }
        }


        public async Task<Stream> LoadCoverBitmapAsync()
        {

            return new MemoryStream();
        }

        public static async Task<List<User>> UserListAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");
                
                
                var resData = await s_httpClient.GetAsync("UserList");
                try
                {
                    resData.EnsureSuccessStatusCode();
                    string stringResponse = await resData.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<User>>(stringResponse);
                    //Text.json List<Music> searchResults = JsonSerializer.Deserialize<List<Music>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("user List error");
                    return new List<User>();
                }
            }
        }
    }
    
}
