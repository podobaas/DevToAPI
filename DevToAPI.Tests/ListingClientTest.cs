using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Listings;
using DevToAPI.Http;
using DevToAPI.Models.Enums;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class ListingClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);

            await client.GetAsync();

            await apiConnection.Received().ExecutePaginationGetAsync<Listing>("listings", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetByCategoryAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);

            await client.GetByCategoryAsync(CategoryListing.Events);

            await apiConnection.Received().ExecutePaginationGetAsync<Listing>("listings/category/events", Arg.Any<PageQueryOption>());
        }
        
        [TestMethod]
        public async Task GetByIdAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);

            await client.GetByIdAsync(1);

            await apiConnection.Received().ExecuteGetAsync<Listing>("listings/1");
        }
        
        [TestMethod]
        public async Task GetByIdAsync_IdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByIdAsync(0));
            await apiConnection.DidNotReceive().ExecuteGetAsync<Listing>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task CreateAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);

            await client.CreateAsync(new CreateListing());

            await apiConnection.Received().ExecutePostAsync<object, Listing>("listings", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task CreateAsync_CreateListingNull_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.CreateAsync(null));
            await apiConnection.DidNotReceive().ExecutePostAsync<object, Listing>("listings", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task UpdateAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);

            await client.UpdateAsync(1, new UpdateListing());

            await apiConnection.Received().ExecutePutAsync<object, Listing>("listings/1", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task UpdateAsync_UpdateListingNull_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.UpdateAsync(1, null));
            await apiConnection.DidNotReceive().ExecutePutAsync<object, Listing>(Arg.Any<string>(), Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task UpdateAsync_ListingIdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new ListingClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.UpdateAsync(0, new UpdateListing()));
            await apiConnection.DidNotReceive().ExecutePutAsync<object, Listing>(Arg.Any<string>(), Arg.Any<object>());
        }
    }
}