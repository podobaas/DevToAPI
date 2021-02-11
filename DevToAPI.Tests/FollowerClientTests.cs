using System.Threading.Tasks;
using DevToAPI.Clients.Followers;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class FollowerClientTests
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new FollowerClient(apiConnection);

            await client.GetAsync();
            
            await apiConnection.Received().ExecutePaginationGetAsync<UserFollower>("followers/users", Arg.Any<PageQueryOption>());
        }
    }
}