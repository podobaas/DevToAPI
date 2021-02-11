using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Followers
{
    internal sealed class FollowerClient: ClientBase, IFollowerClient
    {
        protected override string Route => "followers";

        public FollowerClient(IApiConnection apiConnection) : base(apiConnection) { }
        
        public async Task<IPagination<UserFollower>> GetAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<UserFollower>($"{Route}/users", queryOption).ConfigureAwait(false);
        }
    }
}