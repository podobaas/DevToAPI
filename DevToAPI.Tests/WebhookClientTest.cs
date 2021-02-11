using System;
using System.Threading.Tasks;
using DevToAPI.Clients.Webhooks;
using DevToAPI.Http;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DevToAPI.Tests
{
    [TestClass]
    public class WebhookClientTest
    {
        [TestMethod]
        public async Task GetAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);

            await client.GetAsync();

            await apiConnection.Received().ExecuteGetCollectionAsync<Webhook>("webhooks");
        }
        
        [TestMethod]
        public async Task GetByIdAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);

            await client.GetByIdAsync(1);

            await apiConnection.Received().ExecuteGetAsync<WebhookInfo>("webhooks/1");
        }
        
        [TestMethod]
        public async Task GetByIdAsync_WebhookIdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.GetByIdAsync(0));
            await apiConnection.DidNotReceive().ExecuteGetAsync<WebhookInfo>(Arg.Any<string>());
        }
        
        [TestMethod]
        public async Task CreateAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);

            await client.CreateAsync(new CreateWebhook());

            await apiConnection.Received().ExecutePostAsync<object,WebhookInfo>("webhooks", Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task CreateAsync_WebhookNull_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await client.CreateAsync(null));
            await apiConnection.DidNotReceive().ExecutePostAsync<object,WebhookInfo>(Arg.Any<string>(), Arg.Any<object>());
        }
        
        [TestMethod]
        public async Task DeleteAsync()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);

            await client.DeleteAsync(1);

            await apiConnection.Received().ExecuteDeleteAsync("webhooks/1");
        }
        
        [TestMethod]
        public async Task DeleteAsync_WebhookIdZero_Throw()
        {
            var apiConnection = Substitute.For<IApiConnection>();
            var client = new WebhookClient(apiConnection);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await client.DeleteAsync(0));
            await apiConnection.DidNotReceive().ExecuteDeleteAsync(Arg.Any<string>());
        }
    }
}