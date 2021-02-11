using DevToAPI.Types.Attributes;

namespace DevToAPI.Models.Requests.QueryOptions
{
    public class PageQueryOption
    {
        internal PageQueryOption()
        {
            Page = 1;
            PageSize = 30;
        }
        
        /// <summary>
        /// Pagination page
        /// Default: 1
        /// </summary>
        [QueryParam("page")]
        public int Page { get; set; }
        
        /// <summary>
        /// Page size (the number of items to return per page.
        /// Default: 30.
        /// </summary>
        [QueryParam("per_page")]
        public int PageSize { get; set; }
    }
}