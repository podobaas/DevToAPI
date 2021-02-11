using System.Threading.Tasks;
using DevToAPI.Clients.Follows;
using DevToAPI.Http;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class FollowClientTest
    {
        [TestMethod]
        public async Task GetTagsAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new FollowClient(apiConnection);

            await client.GetTagsAsync();

            await apiConnection.Received().ExecuteGetCollectionAsync<FollowedTag>("follows/tags");
        }
    }
}