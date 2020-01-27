using Imdb.Interfaces;
using Imdb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.Services
{
    public class ApiHandler<TMedia> where TMedia : class, IMedia
    {
        private static string ApiKey = "21e7a44b";
        private static HttpClient client;

        public static void InitializeHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TMedia> GetMedias(string searchTerm, int page, string type)
        {
            InitializeHttpClient();
            var response = await client.GetAsync($"?s={searchTerm}&type={type}&page={page}&apikey={ApiKey}");
            var data = JsonConvert.DeserializeObject<TMedia>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public static async Task<TMedia> GetMedia(string searchTerm, string type)
        {
            InitializeHttpClient();
            var response = await client.GetAsync($"?t={searchTerm}&type={type}&apikey={ApiKey}");
            var data = JsonConvert.DeserializeObject<TMedia>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public static async Task<TMedia> GetMediaById(string id, string type)
        {
            InitializeHttpClient();
            var response = await client.GetAsync($"?i={id}&type={type}&apikey={ApiKey}");
            var data = JsonConvert.DeserializeObject<TMedia>(await response.Content.ReadAsStringAsync());
            return data;
        }
    }
}
