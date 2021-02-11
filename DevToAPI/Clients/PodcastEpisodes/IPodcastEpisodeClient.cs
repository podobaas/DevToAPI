using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.PodcastEpisodes
{
    /// <summary>
    /// Podcast episodes
    /// </summary>
    public interface IPodcastEpisodeClient
    {
        /// <summary>
        /// Retrieve a list of podcast episodes.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getPodcastEpisodes">getPodcastEpisodes</a> for more information.
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<PodcastEpisode>> GetAsync(Action<PageQueryOption> action = null);

        /// <summary>
        /// Retrieve a list of podcast episodes.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getPodcastEpisodes">getPodcastEpisodes</a> for more information.
        /// </remarks>
        /// <param name="username">Username of the podcast</param>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<PodcastEpisode>> GetByUsernameAsync(string username, Action<PageQueryOption> action = null);
    }
}