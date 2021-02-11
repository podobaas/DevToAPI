using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Responses;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.ProfileImages
{
    internal sealed class ProfileImageClient: ClientBase, IProfileImageClient
    {
        protected override string Route => "profile_images";
        
        public ProfileImageClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<ProfileImage> GetAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));

            return await ApiConnection.ExecuteGetAsync<ProfileImage>($"{Route}/{username}").ConfigureAwait(false);
        }
    }
}