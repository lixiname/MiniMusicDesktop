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

namespace MiniMusicDesktop.Models
{
    public class Music
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("uploadUserId")]
        public int UploadUserId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("musicImageUrl")]
        public string? MusicImageUrl { get; set; }
        [JsonProperty("author")]
        public string? Author { get; set; }
        [JsonProperty("musicContentUrl")]
        public string? MusicContentUrl { get; set; }
        [JsonProperty("musicType")]
        public int? MusicType { get; set; }
        [JsonProperty("review")]
        public int Review { get; set; }
        [JsonProperty("downLoadNum")]
        public int DownLoadNum { get; set; }
        [JsonProperty("agreedNum")]
        public int AgreedNum { get; set; }
        [JsonProperty("talkNum")]
        public int TalkNum { get; set; }

        private static HttpClient s_httpClient = new();
        

        public static async Task<List<Music>> SearchAsync()
        {
            s_httpClient.BaseAddress = new Uri("https://localhost:7151");

            var data = await s_httpClient.GetAsync("Search");
           
            data.EnsureSuccessStatusCode();
            //catch (HttpRequestException e)
            string stringResponse = await data.Content.ReadAsStringAsync();
            var searchResults = JsonConvert.DeserializeObject<List<Music>>(stringResponse);
            //Text.json List<Music> searchResults = JsonSerializer.Deserialize<List<Music>>(stringResponse);
            return searchResults;

        }

        public async Task<Stream> LoadCoverBitmapAsync()
        {
            var data = await s_httpClient.GetByteArrayAsync($"Image?id={Id}");
            return new MemoryStream(data);

           

        }
    }
}
