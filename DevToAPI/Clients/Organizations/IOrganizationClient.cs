using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Organizations
{
    /// <summary>
    /// Users can create and join organizations
    /// </summary>
    public interface IOrganizationClient
    {
        /// <summary>
        /// Retrieve a single organization by their username.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getOrganization">getOrganization</a> for more information.
        /// </remarks>
        /// <param name="username">Username of the organization.</param>
        /// <returns></returns>
        Task<OrganizationInfo> GetByUsernameAsync(string username);

        /// <summary>
        /// Retrieve a list of users belonging to the organization.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getOrgUsers">getOrgUsers</a> for more information
        /// </remarks>
        /// <param name="username">Username of the organization</param>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<UserInfo>> GetUsersAsync(string username, Action<PageQueryOption> action = null);
        
        /// <summary>
        /// Retrieve a list of Articles belonging to the organization.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getOrgUsers">getOrgUsers</a> for more information.
        /// </remarks>
        /// <param name="username">Username of the organization</param>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<Article>> GetArticlesAsync(string username, Action<PageQueryOption> action = null);
        
        /// <summary>
        /// Retrieve a list of listings belonging to the organization.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getOrgListings">getOrgListings</a> for more information.
        /// </remarks>
        /// <param name="username">Username of the organization</param>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<Listing>> GetListingsAsync(string username, Action<PageQueryOption> action = null);
    }
}