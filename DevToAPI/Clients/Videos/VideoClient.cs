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

namespace DevToAPI.Clients.Videos
{
    internal sealed class VideoClient: ClientBase, IVideoClient
    {
        protected override string Route => "videos";
        
        public VideoClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<IPagination<VideoArticle>> GetArticlesAsync()
        {
            return await ApiConnection.ExecutePaginationGetAsync<VideoArticle>(Route, new PageQueryOption()).ConfigureAwait(false);
        }

        public async Task<IPagination<VideoArticle>> GetArticlesAsync(Action<PageQueryOption> action)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));

            return await ApiConnection.ExecutePaginationGetAsync<VideoArticle>(Route, queryOption).ConfigureAwait(false);
        }
    }
}