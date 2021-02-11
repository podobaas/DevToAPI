using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Listing
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; }  

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("title")]
        public string Title { get; private set; }  

        [JsonProperty("slug")]
        public string Slug { get; private set; }  

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; private set; }  

        [JsonProperty("tag_list")]
        public string TagList { get; private set; }  

        [JsonProperty("tags")]
        public List<string> Tags { get; private set; }  

        [JsonProperty("category")]
        public string Category { get; private set; }  

        [JsonProperty("processed_html")]
        public string ProcessedHtml { get; private set; }  

        [JsonProperty("published")]
        public bool Published { get; private set; } 

        [JsonProperty("user")]
        public User User { get; private set; }  

        [JsonProperty("organization")]
        public Organization Organization { get; private set; }  
    }
}