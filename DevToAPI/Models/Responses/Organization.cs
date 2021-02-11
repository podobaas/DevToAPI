using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Organization
    {
        [JsonProperty("name")]
        public string Name { get; private set; } 

        [JsonProperty("username")]
        public string Username { get; private set; } 

        [JsonProperty("slug")]
        public string Slug { get; private set; } 

        [JsonProperty("profile_image")]
        public string ProfileImage { get; private set; } 

        [JsonProperty("profile_image_90")]
        public string ProfileImageSmall { get; private set; } 
    }
}