using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class UserInfo
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("username")]
        public string Username { get; private set; } 

        [JsonProperty("name")]
        public string Name { get; private set; } 

        [JsonProperty("summary")]
        public string Summary { get; private set; }  

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; private set; } 

        [JsonProperty("github_username")]
        public string GithubUsername { get; private set; }  

        [JsonProperty("website_url")]
        public object WebsiteUrl { get; private set; }  

        [JsonProperty("location")]
        public string Location { get; private set; } 

        [JsonProperty("joined_at")]
        public string JoinedAt { get; private set; }  

        [JsonProperty("profile_image")]
        public string ProfileImage { get; private set; }  
    }
}