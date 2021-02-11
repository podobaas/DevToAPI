using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class User
    {
        [JsonProperty("name")]
        public string Name { get; private set; } 

        [JsonProperty("username")]
        public string Username { get; private set; } 

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; private set; } 

        [JsonProperty("github_username")]
        public string GithubUsername { get; private set; } 

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; private set; } 

        [JsonProperty("profile_image")]
        public string ProfileImage { get; private set; } 

        [JsonProperty("profile_image_90")]
        public string ProfileImageSmall{ get; private set; } 
    }
}