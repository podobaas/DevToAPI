using System.Threading.Tasks;
using DevToAPI.Clients.Tags;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class TagClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new TagClient(apiConnection);

            await client.GetAsync();

            await apiConnection.Received().ExecutePaginationGetAsync<TagArticle>("tags", Arg.Any<PageQueryOption>());
        }
    }
}