using System;
using System.Threading.Tasks;
using DevToAPI.Clients.PodcastEpisodes;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class PodcastEpisodeClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new PodcastEpisodeClient(apiConnection);

            await client.GetAsync();

            await apiConnection.Received().ExecutePaginationGetAsync<PodcastEpisode>("podcast_episodes", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetByUsernameAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new PodcastEpisodeClient(apiConnection);

            await client.GetByUsernameAsync("test");

            await apiConnection.Received().ExecutePaginationGetAsync<PodcastEpisode>("podcast_episodes?username=test", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetByUsernameAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new PodcastEpisodeClient(apiConnection);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetByUsernameAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecutePaginationGetAsync<PodcastEpisode>(Arg.Any<string>(), Arg.Any<PageQueryOption>());
        }
    }
}