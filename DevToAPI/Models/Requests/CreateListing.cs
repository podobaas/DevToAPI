using System;
using System.Collections.Generic;
using DevToAPI.Models.Enums;
using Newtonsoft.Json;

namespace DevToAPI.Models.Requests
{
    public sealed class CreateListing
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
        
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; } 
        
        [JsonProperty("contact_via_connect")]
        public bool? ContactViaConnect { get; set; } 
        
        [JsonProperty("location")]
        public string Location { get; set; } 
        
        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonProperty("action")] 
        public ActionListing? Action { get; set; }
    }
}