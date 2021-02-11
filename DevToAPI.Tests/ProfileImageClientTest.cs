using System;
using System.Threading.Tasks;
using DevToAPI.Clients.ProfileImages;
using DevToAPI.Http;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class ProfileImageClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ProfileImageClient(apiConnection);

            await client.GetAsync("test");

            await apiConnection.Received().ExecuteGetAsync<ProfileImage>("profile_images/test");
        }

        [TestMethod]
        public async Task GetAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ProfileImageClient(apiConnection);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecuteGetAsync<ProfileImage>(Arg.Any<string>());
        }
    }
}