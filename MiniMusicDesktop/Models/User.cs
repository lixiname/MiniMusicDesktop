using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models
{
    public class User
    {
        //[JsonProperty("Id")]
        public int Id { get; set; }
        //[JsonProperty("Password")]
        public string Password { get; set; } = string.Empty;
        public int InfoTypes { get; set; } = 0;
        public int LoginSuccess { get; set; } = 0;

        private static HttpClient s_httpClient = new();
        public static async Task<User> LoginAsync(int id,string password)
        {
            s_httpClient.BaseAddress = new Uri("https://localhost:7151");

            var data = new { Id = id, Password = password };
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var resData = await s_httpClient.PostAsync("UserLogin", content);
            try
            {
                resData.EnsureSuccessStatusCode();
                string stringResponse = await resData.Content.ReadAsStringAsync();
                var searchResults = JsonConvert.DeserializeObject<User>(stringResponse);
                searchResults!.LoginSuccess=1;
                return searchResults;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("user login error");
                return new User {Id=id,Password=password,InfoTypes=0,LoginSuccess=0 };
            }
        }
    }
    
}
