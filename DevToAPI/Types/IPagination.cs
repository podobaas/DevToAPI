using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevToAPI.Types
{
    public interface IPagination<TResponse>
    {
        int Page { get;}
        
        int PageSize { get; }
        
        bool CanMoveNext { get; }

        IList<TResponse> Items { get; }

        Task NextPageAsync();
    }
}