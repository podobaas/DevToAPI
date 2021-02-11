using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class VideoArticle
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("path")]
        public string Path { get; private set; } 

        [JsonProperty("cloudinary_video_url")]
        public string CloudinaryVideoUrl { get; private set; } 

        [JsonProperty("title")]
        public string Title { get; private set; } 

        [JsonProperty("user_id")]
        public int UserId { get; private set; } 

        [JsonProperty("video_duration_in_minutes")]
        public string VideoDurationInMinutes { get; private set; } 

        [JsonProperty("video_source_url")]
        public string VideoSourceUrl { get; private set; } 

        [JsonProperty("user")]
        public User User { get; private set; } 
    }
}