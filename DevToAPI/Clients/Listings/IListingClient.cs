using System;
using System.Threading.Tasks;
using DevToAPI.Models.Enums;
using DevToAPI.Models.Requests;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.Listings
{
    /// <summary>
    /// Listings are classified ads
    /// </summary>
    public interface IListingClient
    {
        /// <summary>
        /// Retrieve a list of listings.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getListings">getListings</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<Listing>> GetAsync();
        
        /// <summary>
        /// Retrieve a list of listings.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getListings">getListings</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<Listing>> GetAsync(Action<PageQueryOption> action);
        
        /// <summary>
        /// Retrieve a list of listings belonging to the specified category.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getListingsByCategory">getListingsByCategory</a> for more information
        /// </remarks>
        /// <param name="category">The category of the listing</param>
        /// <returns></returns>
        Task<IPagination<Listing>> GetByCategoryAsync(CategoryListing category);

        /// <summary>
        /// Retrieve a list of listings belonging to the specified category.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getListingsByCategory">getListingsByCategory</a> for more information
        /// </remarks>
        /// <param name="category">The category of the listing</param>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<Listing>> GetByCategoryAsync(CategoryListing category, Action<PageQueryOption> action);

        /// <summary>
        /// Retrieve a list of listings belonging to the specified category.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getListingById">getListingById</a> for more information
        /// </remarks>
        /// <param name="listingId">Id of the listing</param>
        /// <returns></returns>
        Task<Listing> GetByIdAsync(long listingId);
        
        /// <summary>
        /// Create a new listing.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/createListing">createListing</a> for more information
        /// </remarks>
        /// <param name="listing">New listing</param>
        /// <returns></returns>
        Task<Listing> CreateAsync(CreateListing listing);

        /// <summary>
        /// Update an existing listing.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/updateListing">updateListing</a> for more information
        /// </remarks>
        /// <param name="listingId">Id of the listing</param>
        /// <param name="listing">Listing</param>
        /// <returns></returns>
        Task<Listing> UpdateAsync(long listingId, UpdateListing listing);
    }
}