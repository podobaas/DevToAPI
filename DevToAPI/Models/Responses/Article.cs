using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Article
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

        [JsonProperty("readable_publish_date")]
        public string ReadablePublishDate { get; private set; } 

        [JsonProperty("social_image")]
        public string SocialImage { get; private set; }  

        [JsonProperty("tag_list")]
        public List<string> TagList { get; private set; }  

        [JsonProperty("tags")]
        public string Tags { get; private set; }  

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

        [JsonProperty("collection_id")]
        public object CollectionId { get; private set; }  

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }  

        [JsonProperty("edited_at")]
        public DateTime EditedAt { get; private set; }  

        [JsonProperty("crossposted_at")]
        public object CrosspostedAt { get; private set; }  

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; private set; }  

        [JsonProperty("last_comment_at")]
        public DateTime LastCommentAt { get; private set; }  

        [JsonProperty("published_timestamp")]
        public DateTime PublishedTimestamp { get; private set; }  

        [JsonProperty("user")]
        public User User { get; private set; }  

        [JsonProperty("organization")]
        public Organization Organization { get; private set; }  
    }
}