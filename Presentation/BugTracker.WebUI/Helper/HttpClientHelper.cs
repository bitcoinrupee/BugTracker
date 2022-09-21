using BugTracker.Entities.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BugTracker.WebUI.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _client;

        public HttpClientHelper(HttpClient client)
        {
            _client = client;
        }

        public async Task<BugDTO> GetBugByID(int bugId)
        {
            var result = await _client.GetAsync($"api/Bug/Get/{bugId}");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BugDTO>(response);
        }

        public async Task<IEnumerable<BugDTO>> GetBugList()
        {
            var result = await _client.GetAsync("api/Bug/Search");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<BugDTO>>(response);
        }

        public async Task CreateBug(BugDTO bug)
        {
            await SendAsync<BugDTO>("api/Bug/Save", bug);

        }
        public async Task SendAsync<T>(string segment, T obj)
        {

            string param = JsonConvert.SerializeObject(obj);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(param, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(segment, content);
            response.EnsureSuccessStatusCode();

        }
    }
}
