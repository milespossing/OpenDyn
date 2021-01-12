using System.Net;
using System.Threading.Tasks;

namespace HomeWorkerService
{
    public interface IIpClient
    {
        Task<IPAddress> GetIp();
    }
}