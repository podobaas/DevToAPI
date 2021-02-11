using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Responses;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Users
{
    internal sealed class UserClient: ClientBase, IUserClient
    {
        protected override string Route => "users";
        
        public UserClient(IApiConnection apiConnection):base(apiConnection){}
        
        public async Task<UserInfo> GetMeAsync()
        {
            return await ApiConnection.ExecuteGetAsync<UserInfo>($"{Route}/me").ConfigureAwait(false);
        }
        
        public async Task<UserInfo> GetByIdAsync(int userId)
        {
            ThrowHelper.ThrowIfLessThanOne(userId, nameof(userId));
            
            return await ApiConnection.ExecuteGetAsync<UserInfo>($"{Route}/{userId.ToString()}").ConfigureAwait(false);
        }
        
        public async Task<UserInfo> GetByUsernameAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));

            return await ApiConnection.ExecuteGetAsync<UserInfo>($"{Route}/by_username?url={username}").ConfigureAwait(false);
        }
    }
}