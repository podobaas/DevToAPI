using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Followers
{
    /// <summary>
    /// Resources are user can follow
    /// </summary>
    public interface IFollowerClient
    {
        /// <summary>
        /// Retrieve a list of the followers they have.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getFollowers">getFollowers</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<UserFollower>> GetAsync();
        
        /// <summary>
        /// Retrieve a list of the followers they have.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getFollowers">getFollowers</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<UserFollower>> GetAsync(Action<PageQueryOption> action);
    }
}