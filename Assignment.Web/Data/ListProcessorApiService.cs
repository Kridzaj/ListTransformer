using Assignment.Application.DTO;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Assignment.Web.Data
{
    public class ListProcessorApiService : IListProcessorApi
    {
        private readonly HttpClient _client;
        public ListProcessorApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Guid> ProcessList(string name, string lastName)
        {
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _client.GetAsync($"{name}/{lastName}");
            string str = await response.Content.ReadAsStringAsync();
            str = str.Replace("\"", "");

            return Guid.Parse(str);
        }

        public async Task<ProcessRequestDto> GetStatus(Guid guid)
        {
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _client.GetAsync($"{guid}");
            var data = await response.Content.ReadAsStringAsync();

            return System.Text.Json.JsonSerializer.Deserialize<ProcessRequestDto>(data);
        }
    }
}
