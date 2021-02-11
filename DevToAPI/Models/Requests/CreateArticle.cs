using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevToAPI.Models.Requests
{
    public sealed class CreateArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; } 
        
        [JsonProperty("published")]
        public bool Published { get; set; } 
        
        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; set; } 
        
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } 
        
        [JsonProperty("series")]
        public string Series { get; set; } 
        
        [JsonProperty("canonical_url")]
        public string CanonicalUrl { get; set; } 
    }
}