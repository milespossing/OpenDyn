using System.Net;

namespace OpenDyn.Server.IpAddresses
{
    public interface IIpAddressContainer
    {
        IPAddress Address { get; set; }
    }
}