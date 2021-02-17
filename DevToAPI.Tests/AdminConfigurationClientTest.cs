using System;
using System.Threading.Tasks;
using DevToAPI.Clients.AdminConfigurations;
using DevToAPI.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class AdminConfigurationClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new AdminConfigurationClient(apiClient);
            
            await client.GetAsync<object>();
            
            await apiClient.Received().ExecuteGetAsync<object>("admin/config");
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new AdminConfigurationClient(apiClient);

            await client.UpdateAsync(new {test = "test"});
            
            await apiClient.Received().ExecutePutAsync("admin/config", Arg.Any<object>());
        }
        
        [TestMethod] 
        public async Task UpdateAsync_RequestNull_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            
            var client = new AdminConfigurationClient(apiClient);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.UpdateAsync<object>(null));
            await apiClient.DidNotReceive().ExecutePutAsync("admin/config", Arg.Any<object>());
        }
    }
}