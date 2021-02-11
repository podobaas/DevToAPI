using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class MyArticle
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("title")]
        public string Title { get; private set; } 

        [JsonProperty("description")]
        public string Description { get; private set; } 

        [JsonProperty("cover_image")]
        public string CoverImage { get; private set; } 

        [JsonProperty("published")]
        public bool Published { get; private set; } 

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; private set; } 

        [JsonProperty("tag_list")]
        public List<string> TagList { get; private set; } 

        [JsonProperty("slug")]
        public string Slug { get; private set; } 

        [JsonProperty("path")]
        public string Path { get; private set; } 

        [JsonProperty("url")]
        public string Url { get; private set; } 

        [JsonProperty("canonical_url")]
        public string CanonicalUrl { get; private set; } 

        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; } 

        [JsonProperty("positive_reactions_count")]
        public int PositiveReactionsCount { get; private set; } 

        [JsonProperty("public_reactions_count")]
        public int PublicReactionsCount { get; private set; } 

        [JsonProperty("page_views_count")]
        public int PageViewsCount { get; private set; } 

        [JsonProperty("published_timestamp")]
        public DateTime PublishedTimestamp { get; private set; } 

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; private set; } 

        [JsonProperty("user")]
        public User User { get; private set; } 

        [JsonProperty("organization")]
        public Organization Organization { get; private set; } 

        [JsonProperty("flare_tag")]
        public TagArticle FlareTag { get; private set; } 
    }
}