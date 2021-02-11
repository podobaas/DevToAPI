using System.Threading.Tasks;
using DevToAPI.Clients.Videos;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class VideoClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new VideoClient(apiConnection);

            await client.GetArticlesAsync();

            await apiConnection.Received().ExecutePaginationGetAsync<VideoArticle>("videos", Arg.Any<PageQueryOption>());
        }
    }
}