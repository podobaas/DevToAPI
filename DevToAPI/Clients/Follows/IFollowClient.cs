using System.Collections.Generic;
using System.Threading.Tasks;
using DevToAPI.Models.Responses;

namespace DevToAPI.Clients.Follows
{
    /// <summary>
    /// Users can follow other users on the website
    /// </summary>
    public interface IFollowClient
    {
        /// <summary>
        /// Retrieve a list of the tags they follow.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getFollowedTags">getFollowedTags</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IReadOnlyList<FollowedTag>> GetTagsAsync();
    }
}