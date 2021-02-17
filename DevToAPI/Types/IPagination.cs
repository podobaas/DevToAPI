using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevToAPI.Types
{
    public interface IPagination<TResponse>
    {
        /// <summary>
        /// Current page
        /// </summary>
        int Page { get;}
        
        /// <summary>
        /// Current page size
        /// </summary>
        int PageSize { get; }
        
        /// <summary>
        /// This flag indicates can we receive new data
        /// </summary>
        bool CanMoveNext { get; }

        /// <summary>
        /// Response items
        /// </summary>
        IList<TResponse> Items { get; }

        /// <summary>
        /// Receiving a next page
        /// </summary>
        /// <returns></returns>
        Task NextPageAsync();
    }
}