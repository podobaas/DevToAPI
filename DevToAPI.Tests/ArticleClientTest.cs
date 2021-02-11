using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Articles;
using DevToAPI.Http;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class ArticleClientTest
    {
        [TestMethod]
        public async Task CreateAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await client.CreateAsync(new CreateArticle());
            
            await apiClient.Received().ExecutePostAsync<object, Article>("articles", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task CreateAsync_RequestNull_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.CreateAsync(null));
            
            await apiClient.DidNotReceive().ExecutePostAsync<object, Article>("articles", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task UpdateAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await client.UpdateAsync(1, new UpdateArticle());
            
            await apiClient.Received().ExecutePutAsync<object, Article>("articles/1", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task UpdateAsync_ArticleIdZero_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.UpdateAsync(0, new UpdateArticle()));
            
            await apiClient.DidNotReceive().ExecutePostAsync<object, Article>("articles/0", Arg.Any<object>());
        }

        [TestMethod] 
        public async Task UpdateAsync_RequestNull_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            
            var client = new ArticleClient(apiClient);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.UpdateAsync(1, null));
            await apiClient.DidNotReceive().ExecutePostAsync<object, Article>("articles/1", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task GetByPathAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await client.GetByPathAsync("test", "test");
            
            await apiClient.Received().ExecuteGetAsync<Article>("articles/test/test");
        }
        
        [TestMethod]
        public async Task GetByPathAsync_EmptyUsername_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetByPathAsync(string.Empty, "test"));
            await apiClient.DidNotReceive().ExecuteGetAsync<Article>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task GetByIdAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await client.GetByIdAsync(1);
            
            await apiClient.Received().ExecuteGetAsync<Article>("articles/1");
        }
        
        [TestMethod]
        public async Task GetByIdAsync_ArticleIdZero_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByIdAsync(0));
            await apiClient.DidNotReceive().ExecuteGetAsync<Article>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task GetAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await client.GetAsync();
            
            await apiClient.Received().ExecutePaginationGetAsync<Article>("articles", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetAsync_TopZero_Throw()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await client.GetAsync();
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetAsync(option =>
            {
                option.Top = 0;
            }));
            
            await apiClient.DidNotReceive().ExecutePaginationGetAsync<Article>("articles", new ArticleQueryOption()
            {
                Top = 0
            });
        }
        
        [TestMethod]
        public async Task GetAllMyAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await client.GetAllMyAsync();
            
            await apiClient.Received().ExecutePaginationGetAsync<MyArticle>("articles/me/all", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetMyUnpublishedAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await client.GetMyUnpublishedAsync();
            
            await apiClient.Received().ExecutePaginationGetAsync<MyArticle>("articles/me/unpublished", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetMyPublishedAsync()
        {
            var apiClient = Substitute.For<IApiConnection>();
            var client = new ArticleClient(apiClient);

            await client.GetMyPublishedAsync();
            
            await apiClient.Received().ExecutePaginationGetAsync<MyArticle>("articles/me/published", Arg.Any<PageQueryOption>());
        }
    }
}