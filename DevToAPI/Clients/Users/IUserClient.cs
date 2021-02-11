using System.Threading.Tasks;
using DevToAPI.Models.Responses;

namespace DevToAPI.Clients.Users
{
    /// <summary>
    /// Users own resources that require authentication
    /// </summary>
    public interface IUserClient
    {
        /// <summary>
        /// Retrieve information about the authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUser">getUser</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<UserInfo> GetMeAsync();
        
        /// <summary>
        /// Retrieve a single user by id.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUser">getUser</a> for more information
        /// </remarks>
        /// <param name="userId">Id of the user</param>
        /// <returns></returns>
        Task<UserInfo> GetByIdAsync(int userId);
        
        /// <summary>
        /// Retrieve a single user by username.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getUser">getUser</a> for more information
        /// </remarks>
        /// <param name="username">User's username</param>
        /// <returns></returns>
        Task<UserInfo> GetByUsernameAsync(string username);
    }
}