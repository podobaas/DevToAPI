using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Comment
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id_code")]
        public string IdCode { get; private set; }  

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }  

        [JsonProperty("body_html")]
        public string BodyHtml { get; private set; }  

        [JsonProperty("user")]
        public User User { get; private set; }  

        [JsonProperty("children")]
        public IEnumerable<Comment> Children { get; private set; } 
    }
}