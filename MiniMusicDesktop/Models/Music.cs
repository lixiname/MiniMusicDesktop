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
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.DTO;

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


        public static async Task<List<Music>> SearchReviewAsync(string ?searchKey)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);

                
                string endpoint = "SearchReview";
                string queryString = $"?searchKey={searchKey}"; 
                string requestUrl = endpoint + queryString;
                var data = await s_httpClient.GetAsync(requestUrl);
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

        public static async Task<List<User>> SearchUserRemarkMusicAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);


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


        


        public async Task<Stream> LoadCoverBitmapAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);
                var data = await s_httpClient.GetByteArrayAsync($"Image?id={Id}");
                return new MemoryStream(data);
                
            }
                
        }

        public async Task<Stream> LoadMediaBitmapAsync()
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);
                var data = await s_httpClient.GetByteArrayAsync($"Media?id={Id}");
                return new MemoryStream(data);

            }

        }


        public static async Task<List<MusicCollectedTopSortDTO>> SearchBarChartAsync(YearEnum year,MonthEnum month)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);

                var yearQ=Convert.ToInt32(year)+2023;
                var monthQ = Convert.ToInt32(month)+1;
                string endpoint = "SearchBarChart";
                string queryString = $"?year={yearQ}&&month={monthQ}";
                string requestUrl = endpoint + queryString;
                var data = await s_httpClient.GetAsync(requestUrl);
                try
                {
                    data.EnsureSuccessStatusCode();
                    
                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<MusicCollectedTopSortDTO>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("SearchBarChart review music List error");
                    return new List<MusicCollectedTopSortDTO>();
                }
            }

        }


        public static async Task<List<MusicAgreedTopSortDTO>> SearchLineChartAsync(YearEnum year, MonthEnum month,long musicId)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);

                var yearQ = Convert.ToInt32(year) + 2023;
                var monthQ = Convert.ToInt32(month) + 1;
                string endpoint = "SearchLineChart";
                string queryString = $"?year={yearQ}&&month={monthQ}&&musicId={musicId}";
                string requestUrl = endpoint + queryString;
                var data = await s_httpClient.GetAsync(requestUrl);
                try
                {
                    data.EnsureSuccessStatusCode();

                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<MusicAgreedTopSortDTO>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("SearchLineChart review music List error");
                    return new List<MusicAgreedTopSortDTO>();
                }
            }

        }

        public static async Task<List<MusicDownloadPieDTO>> SearchPieChartAsync(YearEnum year, MonthEnum month)
        {
            using (HttpClient s_httpClient = new())
            {
                s_httpClient.BaseAddress = new Uri(ConfigConstant.BaseUrl);

                var yearQ = Convert.ToInt32(year) + 2023;
                var monthQ = Convert.ToInt32(month) + 1;
                string endpoint = "SearchPieChart";
                string queryString = $"?year={yearQ}&&month={monthQ}";
                string requestUrl = endpoint + queryString;
                var data = await s_httpClient.GetAsync(requestUrl);
                try
                {
                    data.EnsureSuccessStatusCode();

                    string stringResponse = await data.Content.ReadAsStringAsync();
                    var searchResults = JsonConvert.DeserializeObject<List<MusicDownloadPieDTO>>(stringResponse);
                    return searchResults;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("SearchPieChart review music List error");
                    return new List<MusicDownloadPieDTO>();
                }
            }

        }
    }
}
