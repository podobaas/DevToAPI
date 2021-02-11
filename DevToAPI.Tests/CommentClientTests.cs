using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Comments;
using DevToAPI.Http;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class CommentClientTests
    {
        [TestMethod]
        public async Task GetByIdAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);

            await client.GetByIdAsync("123");
            
            await apiConnection.Received().ExecuteGetAsync<Comment>("comments/123");
        }
        
        [TestMethod]
        public async Task GetByIdAsync_CommentIdEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetByIdAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecuteGetAsync<Comment>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task GetByArticleIdAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);

            await client.GetByArticleIdAsync(1);
            
            await apiConnection.Received().ExecuteGetCollectionAsync<Comment>("comments?a_id=1");
        }
        
        [TestMethod]
        public async Task GetByArticleIdAsync_ArticleIdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByArticleIdAsync(0));
            await apiConnection.DidNotReceive().ExecuteGetCollectionAsync<Comment>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task GetByPodcastIdAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);

            await client.GetByPodcastIdAsync(1);
            
            await apiConnection.Received().ExecuteGetCollectionAsync<Comment>("comments?p_id=1");
        }
        
        [TestMethod]
        public async Task GetByPodcastIdAsync_PodcastIdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new CommentClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByPodcastIdAsync(0));
            await apiConnection.DidNotReceive().ExecuteGetCollectionAsync<Comment>(Arg.Any<string>());
        }
    }
}