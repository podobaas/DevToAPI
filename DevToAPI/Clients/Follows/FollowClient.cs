using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Http;
using DevToAPI.Models.Responses;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Follows
{
    internal sealed class FollowClient: ClientBase, IFollowClient
    {
        protected override string Route => "follows";
        
        public FollowClient(IApiConnection apiConnection):base(apiConnection){}

        public async Task<IReadOnlyList<FollowedTag>> GetTagsAsync()
        {
            return await ApiConnection.ExecuteGetCollectionAsync<FollowedTag>($"{Route}/tags").ConfigureAwait(false);
        }
    }
}