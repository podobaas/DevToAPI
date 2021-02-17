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

namespace DevToAPI.Clients.Organizations
{
    internal sealed class OrganizationClient: ClientBase, IOrganizationClient
    {
        protected override string Route => "organizations";

        public OrganizationClient(IApiConnection apiConnection) : base(apiConnection){ }

        public async Task<OrganizationInfo> GetByUsernameAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            
            return await ApiConnection.ExecuteGetAsync<OrganizationInfo>($"{Route}/{username}").ConfigureAwait(false);
        }

        public async Task<IPagination<UserInfo>> GetUsersAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            
            return await ApiConnection.ExecutePaginationGetAsync<UserInfo>($"{Route}/{username}/users", new PageQueryOption()).ConfigureAwait(false);
        }

        public async Task<IPagination<UserInfo>> GetUsersAsync(string username, Action<PageQueryOption> action)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));

            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<UserInfo>($"{Route}/{username}/users", queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<Article>> GetArticlesAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            
            return await ApiConnection.ExecutePaginationGetAsync<Article>($"{Route}/{username}/articles", new PageQueryOption()).ConfigureAwait(false);
        }

        public async Task<IPagination<Article>> GetArticlesAsync(string username, Action<PageQueryOption> action)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));

            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<Article>($"{Route}/{username}/articles", queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<Listing>> GetListingsAsync(string username)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            
            return await ApiConnection.ExecutePaginationGetAsync<Listing>($"{Route}/{username}/listings", new PageQueryOption()).ConfigureAwait(false);
        }

        public async Task<IPagination<Listing>> GetListingsAsync(string username, Action<PageQueryOption> action = null)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));

            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<Listing>($"{Route}/{username}/listings", queryOption).ConfigureAwait(false);
        }
    }
}