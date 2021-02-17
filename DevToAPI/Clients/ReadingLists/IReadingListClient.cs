using System;
using System.Threading.Tasks;
using DevToAPI.Models.Requests.QueryOptions;
using DevToAPI.Models.Responses;
using DevToAPI.Types;

namespace DevToAPI.Clients.ReadingLists
{
    /// <summary>
    /// User's reading list
    /// </summary>
    public interface IReadingListClient
    {
        /// <summary>
        /// Retrieve a list of readinglist reactions along with the related article for the authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getReadinglist">getReadinglist</a> for more information
        /// </remarks>
        /// <returns></returns>
        Task<IPagination<ReadingList>> GetAsync();
        
        /// <summary>
        /// Retrieve a list of readinglist reactions along with the related article for the authenticated user.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getReadinglist">getReadinglist</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<ReadingList>> GetAsync(Action<PageQueryOption> action);
    }
}