using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevToAPI.Helpers;
using DevToAPI.Http;
using DevToAPI.Models.Enums;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DevToAPI.Tests")]

namespace DevToAPI.Clients.Listings
{
    internal sealed class ListingClient: ClientBase, IListingClient
    {
        protected override string Route => "listings";
        
        public ListingClient(IApiConnection apiConnection) : base(apiConnection){}

        public async Task<IPagination<Listing>> GetAsync(Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));

            return await ApiConnection.ExecutePaginationGetAsync<Listing>(Route, queryOption).ConfigureAwait(false);
        }

        public async Task<IPagination<Listing>> GetByCategoryAsync(CategoryListing category, Action<PageQueryOption> action = null)
        {
            var queryOption = new PageQueryOption();
            action?.Invoke(queryOption);
            
            ThrowHelper.ThrowIfLessThanOne(queryOption.Page, nameof(queryOption.Page));
            ThrowHelper.ThrowIfOutOfRange(queryOption.PageSize, 1, 1000, nameof(queryOption.PageSize));

            return await ApiConnection.ExecutePaginationGetAsync<Listing>($"{Route}/category/{category.ToString().ToLower()}", queryOption).ConfigureAwait(false);
        }

        public async Task<Listing> GetByIdAsync(long listingId)
        {
            ThrowHelper.ThrowIfLessThanOne(listingId, nameof(listingId));

            return await ApiConnection.ExecuteGetAsync<Listing>($"{Route}/{listingId}").ConfigureAwait(false);
        }

        public async Task<Listing> CreateAsync(CreateListing listing)
        {
            ThrowHelper.ThrowIfNull(listing, nameof(listing));

            var request = new {listing};
            return await ApiConnection.ExecutePostAsync<object, Listing>(Route, request).ConfigureAwait(false);
        }

        public async Task<Listing> UpdateAsync(long listingId, UpdateListing listing)
        {
            ThrowHelper.ThrowIfLessThanOne(listingId, nameof(listingId));
            ThrowHelper.ThrowIfNull(listing, nameof(listing));
            
            var request = new {listing};
            return await ApiConnection.ExecutePutAsync<object, Listing>($"{Route}/{listingId}", request).ConfigureAwait(false);
        }
    }
}