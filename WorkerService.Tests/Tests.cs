using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenDyn.Client;

namespace WorkerService.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task CanGetIp()
        {
            var client = new ApiClient(new Uri("http://localhost:5000"));
            var ipAddressAsync = await client.GetIpAddressAsync();
            Assert.That(ipAddressAsync, Is.Not.Null);
        }

        [Test]
        public async Task CanSetIp()
        {
            var newAddress = IPAddress.Parse("192.168.6.1");
            var client = new ApiClient(new Uri("http://localhost:5000"));
            await client.SetIpAddressAsync(newAddress);
            var serverAddress = await client.GetIpAddressAsync();
            Assert.That(serverAddress, Is.EqualTo(newAddress));
        }
    }
}