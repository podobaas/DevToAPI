using System.Collections.Generic;
using System.Threading.Tasks;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Responses;

namespace DevToAPI.Clients.Webhooks
{
    /// <summary>
    /// Webhooks are HTTP endpoints registered to receive events
    /// </summary>
    public interface IWebhookClient
    {
        /// <summary>
        /// Retrieve a list of webhooks they have previously registered.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getWebhooks">getWebhooks</a> for more information.
        /// </remarks>
        /// <returns></returns>
        Task<IReadOnlyList<Webhook>> GetAsync();

        /// <summary>
        /// Retrieve a single webhook given its id.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getWebhookById">getWebhookById</a> for more information.
        /// </remarks>
        /// <param name="webhookId">Id of the webhook</param>
        /// <returns></returns>
        Task<WebhookInfo> GetByIdAsync(long webhookId);

        /// <summary>
        /// Create a new webhook.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/createWebhook">createWebhook</a> for more information.
        /// </remarks>
        /// <param name="webhook">Webhook</param>
        /// <returns></returns>
        Task<WebhookInfo> CreateAsync(CreateWebhook webhook);

        /// <summary>
        /// Delete a single webhook given its id.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/deleteWebhook">deleteWebhook</a> for more information.
        /// </remarks>
        /// <param name="webhookId">Id of the webhook</param>
        /// <returns></returns>
        Task DeleteAsync(long webhookId);
    }
}