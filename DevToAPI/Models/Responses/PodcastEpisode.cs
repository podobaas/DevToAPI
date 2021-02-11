using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class PodcastEpisode
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("path")]
        public string Path { get; private set; } 

        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; } 

        [JsonProperty("title")]
        public string Title { get; private set; } 

        [JsonProperty("podcast")]
        public Podcast Podcast { get; private set; } 
    }
}