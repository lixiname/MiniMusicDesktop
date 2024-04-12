using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

using Newtonsoft.Json;
using Avalonia.Media.Imaging;
using iTunesSearch.Library.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MiniMusicDesktop.Models.Common.Enum;

namespace MiniMusicDesktop.Models
{
    public class Music
    {
       
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("uploadUserId")]
        public long UploadUserId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("musicImageUrl")]
        public string? MusicImageUrl { get; set; }
        [JsonProperty("author")]
        public string? Author { get; set; }
        [JsonProperty("musicContentUrl")]
        public string? MusicContentUrl { get; set; }
        [JsonProperty("musicType")]
        public MusicTypeEnum MusicType { get; set; }
        [JsonProperty("review")]
        public MusicReviewEnum Review { get; set; }
        [JsonProperty("downLoadNum")]
        public int DownLoadNum { get; set; }
        [JsonProperty("agreedNum")]
        public int AgreedNum { get; set; }
        [JsonProperty("talkNum")]
        public int TalkNum { get; set; }
        [JsonProperty("usingNum")]
        public int UsingNum { get; set; }
        [JsonProperty("collectNum")]
        public int CollectNum { get; set; }


        
        public static async Task<List<Music>> SearchAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");

                var data = await s_httpClient.GetAsync("Search");
                try
                {
                    data.EnsureSuccessStatusCode();
                    //catch (HttpRequestException e)
                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<Music>>(stringResponse);
                    //Text.json List<Music> searchResults = JsonSerializer.Deserialize<List<Music>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("music List error");
                    return new List<Music>();
                }
                
            }
                

        }


        public static async Task<List<Music>> SearchReviewAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");

                var data = await s_httpClient.GetAsync("SearchReview");
                try
                {
                    data.EnsureSuccessStatusCode();
                    //catch (HttpRequestException e)
                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<Music>>(stringResponse);
                    //Text.json List<Music> searchResults = JsonSerializer.Deserialize<List<Music>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("review music List error");
                    return new List<Music>();
                }

            }


        }



        public static async Task<List<Music>> SearchUserCollectedMusicAsync(long userId)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");

                var data = await s_httpClient.GetAsync($"CollectSearch?UserId={userId}");
                try
                {
                    data.EnsureSuccessStatusCode();
                    //catch (HttpRequestException e)
                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<Music>>(stringResponse);
                    //Text.json List<Music> searchResults = JsonSerializer.Deserialize<List<Music>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("music List error");
                    return new List<Music>();
                }

            }


        }

        public async Task<Stream> LoadCoverBitmapAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri("https://localhost:7151");
                var data = await s_httpClient.GetByteArrayAsync($"Image?id={Id}");
                return new MemoryStream(data);
                
            }
                
        }
    }
}
