using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Organizations;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class OrganizationClientTest
    {
        [TestMethod]
        public async Task GetByUsernameAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await client.GetByUsernameAsync("test");

            await apiConnection.Received().ExecuteGetAsync<OrganizationInfo>("organizations/test");
        }
        
        [TestMethod]
        public async Task GetByUsernameAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetByUsernameAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecuteGetAsync<OrganizationInfo>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task GetUsersAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await client.GetUsersAsync("test");

            await apiConnection.Received().ExecutePaginationGetAsync<UserInfo>("organizations/test/users", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetUsersAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetUsersAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecutePaginationGetAsync<UserInfo>(Arg.Any<string>(), Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetArticlesAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await client.GetArticlesAsync("test");

            await apiConnection.Received().ExecutePaginationGetAsync<Article>("organizations/test/articles", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetArticlesAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetArticlesAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecutePaginationGetAsync<Article>(Arg.Any<string>(), Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetListingsAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await client.GetListingsAsync("test");

            await apiConnection.Received().ExecutePaginationGetAsync<Listing>("organizations/test/listings", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetListingsAsync_UsernameEmpty_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new OrganizationClient(apiConnection);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.GetListingsAsync(string.Empty));
            await apiConnection.DidNotReceive().ExecutePaginationGetAsync<Listing>(Arg.Any<string>(), Arg.Any<PageQueryOption>());
        }
    }
}