using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenDyn.Data;
using OpenDyn.Server.IpAddresses;

namespace OpenDyn.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpAddressController : ControllerBase
    {
        private readonly ILogger<IpAddressController> _logger;
        private readonly IIpAddressContainer _container;

        public IpAddressController(ILogger<IpAddressController> logger, IIpAddressContainer container)
        {
            _logger = logger;
            _container = container;
        }

        [HttpGet]
        public IpBundle Get()
        {
            _logger.LogInformation($"Returning address {_container.Address}");
            return new IpBundle {IpAddress = _container.Address};
        }

        [HttpPost]
        public void Post([FromBody] IpBundle bundle)
        {
            _logger.LogInformation($"New address {bundle.IpAddress}");
            _container.Address = bundle.IpAddress;
        }
    }
}
