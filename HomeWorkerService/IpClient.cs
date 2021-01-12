using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWorkerService
{
    public class IpClient : IIpClient
    {
        private HttpClient _client;
        
        public IpClient()
        {
            _client = new HttpClient();
        }
        
        public async Task<IPAddress> GetIp()
        {
            var response = await _client.GetAsync("http://icanhazip.com");
            var body = await response.Content.ReadAsStringAsync();
            body = body.Trim('\n');
            return IPAddress.TryParse(body, out var address) ? address : IPAddress.None;
        }
    }
}