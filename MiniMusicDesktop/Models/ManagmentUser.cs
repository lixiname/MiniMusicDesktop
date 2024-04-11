using MiniMusicDesktop.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models
{
   
    public class ManagmentUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
        public InfoTypeEnum InfoTypes { get; set; } = InfoTypeEnum.ManagmentUser;
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

        public static async Task<ManagmentUser> LoginAsync(string userId, string password)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");

                var data = new { UserId = userId, Password = password };
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var resData = await s_httpClient.PostAsync("ManagmentUserLogin", content);
                try
                {
                    resData.EnsureSuccessStatusCode();
                    string stringResponse = await resData.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<ManagmentUser>(stringResponse);
                    searchResults!.LoginSuccess = LoginStateEnum.Login;
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("managment user login error");
                    return new ManagmentUser 
                    { Id = -1, UserId = userId, Password = password, InfoTypes=InfoTypeEnum.NullUser, LoginSuccess = LoginStateEnum.Remove };
                }
            }

        }


        
    }
}
