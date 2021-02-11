using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Videos
{
    /// <summary>
    /// Video articles
    /// </summary>
    public interface IVideoClient
    {
        /// <summary>
        /// Retrieve a list of articles that are uploaded with a video.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getArticlesWithVideo">getArticlesWithVideo</a> for more information.
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<VideoArticle>> GetArticlesAsync(Action<PageQueryOption> action = null);
    }
}