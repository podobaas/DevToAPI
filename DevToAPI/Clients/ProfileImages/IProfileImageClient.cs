using System.Threading.Tasks;
using DevToAPI.Models.Responses;

namespace DevToAPI.Clients.ProfileImages
{
    /// <summary>
    /// User or organization profile images
    /// </summary>
    public interface IProfileImageClient
    {
        /// <summary>
        /// Retrieve a user or organization profile image information by its corresponding username.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getProfileImage">getProfileImage</a> for more information
        /// </remarks>
        /// <param name="username">Username of the user or organization</param>
        /// <returns></returns>
        Task<ProfileImage> GetAsync(string username);
    }
}