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

namespace DevToAPI.Clients.ReadingLists
{
    internal sealed class ReadingListClient: ClientBase, IReadingListClient
    {
        protected override string Route => "readinglist";
        
        public ReadingListClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<IPagination<ReadingList>> GetAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));
            
            return await ApiConnection.ExecutePaginationGetAsync<ReadingList>(Route, queryOption).ConfigureAwait(false);
        }
    }
}