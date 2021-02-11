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

namespace DevToAPI.Clients.PodcastEpisodes
{
    internal sealed class PodcastEpisodeClient: ClientBase, IPodcastEpisodeClient
    {
        protected override string Route => "podcast_episodes";
        
        public PodcastEpisodeClient(IApiConnection apiConnection) : base(apiConnection){}
        
        public async Task<IPagination<PodcastEpisode>> GetAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<PodcastEpisode>(Route, queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<PodcastEpisode>> GetByUsernameAsync(string username, Action<PageQueryOption> action = null)
        {
            ThrowHelper.ThrowIfNullOrEmpty(username, nameof(username));
            
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<PodcastEpisode>($"{Route}?username={username}", queryOption).ConfigureAwait(false);
        }
    }
}