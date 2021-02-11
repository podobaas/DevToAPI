using System.Threading.Tasks;
using DevToAPI.Clients.ReadingLists;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class ReadingListClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ReadingListClient(apiConnection);

            await client.GetAsync();

            await apiConnection.Received().ExecutePaginationGetAsync<ReadingList>("readinglist", Arg.Any<PageQueryOption>());
        }
    }
}