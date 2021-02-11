using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Tags
{
    /// <summary>
    /// Tags for articles
    /// </summary>
    public interface ITagClient
    {
        /// <summary>
        /// Retrieve a list of tags that can be used to tag articles.
        /// It will return N tags per page ordered by popularity.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getTags">getTags</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<TagArticle>> GetAsync(Action<PageQueryOption> action = null);
    }
}