using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Responses;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Webhooks
{
    internal sealed class WebhookClient:ClientBase, IWebhookClient
    {
        protected override string Route => "webhooks";
        
        public WebhookClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<IReadOnlyList<Webhook>> GetAsync()
        {
            return await ApiConnection.ExecuteGetCollectionAsync<Webhook>(Route).ConfigureAwait(false);
        }

        public async Task<WebhookInfo> GetByIdAsync(long webhookId)
        {
            ThrowHelper.ThrowIfLessThanOne(webhookId, nameof(webhookId));

            return await ApiConnection.ExecuteGetAsync<WebhookInfo>($"{Route}/{webhookId}").ConfigureAwait(false);
        }

        public async Task<WebhookInfo> CreateAsync(CreateWebhook webhook)
        {
            ThrowHelper.ThrowIfNull(webhook, nameof(webhook));

            var request = new {webhook_endpoint = webhook};
            return await ApiConnection.ExecutePostAsync<object, WebhookInfo>(Route,request).ConfigureAwait(false);
        }

        public async Task DeleteAsync(long webhookId)
        {
            ThrowHelper.ThrowIfLessThanOne(webhookId, nameof(webhookId));

            await ApiConnection.ExecuteDeleteAsync($"{Route}/{webhookId}").ConfigureAwait(false);
        }
    }
}