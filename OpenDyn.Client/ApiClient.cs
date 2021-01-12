using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenDyn.Data;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OpenDyn.Client
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _settings;

        public ApiClient(Uri address)
        {
            _client = new HttpClient {BaseAddress = address};
            _settings = new JsonSerializerOptions();
            _settings.Converters.Add(new IpAddressConverter());
            _settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }
        
        public async Task<IPAddress> GetIpAddressAsync()
        {
            var response = await _client.GetAsync("IpAddress");
            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IpBundle>(data, _settings).IpAddress;
        }

        public Task SetIpAddressAsync(IPAddress address)
        {
            var bundle = new IpBundle() {IpAddress = address};
            var data = JsonSerializer.Serialize(bundle, _settings);
            return _client.PostAsync("IpAddress", new StringContent(data, Encoding.UTF8, "application/json"));
        }
    }
}