using Assignment.Application.DTO;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ListProcessorApiService> _logger;
        public ListProcessorApiService(HttpClient client, ILogger<ListProcessorApiService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<Guid> ProcessList(string name, string lastName)
        {
            _logger.LogInformation($"Received list for {name} {lastName}");
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{name}/{lastName}");
                string str = await response.Content.ReadAsStringAsync();
                str = str.Replace("\"", "");
                return Guid.Parse(str);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error on processing list");
                throw;
            }
           
        }

        public async Task<ProcessRequestDto> GetStatus(Guid guid)
        {
            _logger.LogInformation($"Fetching status for {guid}");
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{guid}");
                var data = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<ProcessRequestDto>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on get status");
                throw;
            }
           
        }
    }
}
