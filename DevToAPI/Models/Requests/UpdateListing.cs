using System.Collections.Generic;
using DevToAPI.Models.Enums;
using Newtonsoft.Json;

namespace DevToAPI.Models.Requests
{
    public sealed class UpdateListing
    {
        [JsonProperty("title")]
        public string Title { get; set; } 

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; set; } 

        [JsonProperty("category")]
        public CategoryListing Category { get; set; } 

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } 
        
        [JsonProperty("tag_list")]
        public string TagList { get; set; }

        [JsonProperty("action")]
        public ActionListing Action { get; } = ActionListing.Bump;
    }
}