using System.Net;
using System.Threading.Tasks;

namespace OpenDyn.Client
{
    public interface IApiClient
    {
        Task<IPAddress> GetIpAddressAsync();
        Task SetIpAddressAsync(IPAddress address);
    }
}