using DevToAPI.Types.Attributes;

namespace DevToAPI.Models.Requests.QueryOptions
{
    public sealed class ArticleQueryOption: PageQueryOption
    {
        internal ArticleQueryOption()
        {
            Page = 1;
            PageSize = 30;
        }
        
        /// <summary>
        /// Using this parameter will retrieve articles that contain the requested tag.
        /// </summary>
        [QueryParam("tag")]
        public string Tag { get; set; }
        
        /// <summary>
        /// Using this parameter will retrieve articles with any of the comma-separated tags.
        /// </summary>
        [QueryParam("tags")]
        public string Tags { get; set; }
        
        /// <summary>
        /// Using this parameter will retrieve articles that do not contain any of comma-separated tags.
        /// </summary>
        [QueryParam("tags_exclude")]
        public string TagsExclude { get; set; }
        
        /// <summary>
        /// Using this parameter will retrieve articles belonging to a User or Organization ordered by descending publication date.
        /// </summary>
        [QueryParam("username")]
        public string Username { get; set; }
        
        /// <summary>
        /// Using this parameter will allow the client to check which articles are fresh or rising.
        /// </summary>
        [QueryParam("state")]
        public ArticleState State { get; set; }
        
        /// <summary>
        /// Using this parameter will allow the client to return the most popular articles in the last N days.
        /// </summary>
        [QueryParam("top")]
        public int? Top { get; set; }
        
        /// <summary>
        /// Adding this will allow the client to return the list of articles belonging to the requested collection, ordered by ascending publication date.
        /// </summary>
        [QueryParam("collection_id")]
        public int? CollectionId { get; set; }
    }
    
    public enum ArticleState
    {
        [QueryParam("fresh")]
        Fresh,
        
        [QueryParam("rising")]
        Rising,
        
        [QueryParam("all")]
        All
    }
}