using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Users;
using DevToAPI.Http;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class UserClientTest
    {
        [TestMethod]
        public async Task GetMeAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new UserClient(apiClient);

            await client.GetMeAsync();
            
            await apiClient.Received().ExecuteGetAsync<UserInfo>("users/me");
        }
        
        [TestMethod]
        public async Task GetByIdAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new UserClient(apiClient);
            
            await client.GetByIdAsync(1);
            
            await apiClient.Received().ExecuteGetAsync<UserInfo>("users/1");
        }
        
        [TestMethod]
        public async Task GetByIdAsync_UserIdZero_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new UserClient(apiClient);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByIdAsync(0));
            await apiClient.DidNotReceive().ExecuteGetAsync<UserInfo>("users/0");
        }
        
        [TestMethod]
        public async Task GetByUsernameAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new UserClient(apiClient);
            
            await client.GetByUsernameAsync("test");
            
            await apiClient.Received().ExecuteGetAsync<UserInfo>("users/by_username?url=test");
        }
        
        [TestMethod]
        public async Task GetByUsernameAsync_UsernameEmpty_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new UserClient(apiClient);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetByUsernameAsync(string.Empty));
            await apiClient.DidNotReceive().ExecuteGetAsync<UserInfo>(Arg.Any<string>());
        }
    }
}