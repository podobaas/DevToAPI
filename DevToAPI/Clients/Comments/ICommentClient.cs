using System.Collections.Generic;
using System.Threading.Tasks;
using DevToAPI.Models.Responses;

namespace DevToAPI.Clients.Comments
{
    /// <summary>
    /// Users can leave comments to articles and podcasts episodes
    /// </summary>
    public interface ICommentClient
    {
        /// <summary>
        /// Retrieve a comment as well as his descendants comments.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getCommentById">getCommentById</a> for more information
        /// </remarks>
        /// <param name="commentId">Comment identifier.</param>
        /// <returns></returns>
        Task<Comment> GetByIdAsync(string commentId);

        /// <summary>
        /// Retrieve all comments belonging to an article or podcast episode as threaded conversations.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getCommentsByArticleId">getCommentsByArticleId</a> for more information
        /// </remarks>
        /// <param name="articleId">Article identifier.</param>
        /// <returns></returns>
        Task<IReadOnlyList<Comment>> GetByArticleIdAsync(int articleId);
        
        /// <summary>
        /// Retrieve all comments belonging to an article or podcast episode as threaded conversations.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getCommentsByArticleId">getCommentsByArticleId</a> for more information
        /// </remarks>
        /// <param name="podcastId">Podcast Episode identifier.</param>
        /// <returns></returns>
        Task<IReadOnlyList<Comment>> GetByPodcastIdAsync(int podcastId);
    }
}