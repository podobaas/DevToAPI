using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class UserFollower
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("name")]
        public string Name { get; private set; } 

        [JsonProperty("path")]
        public string Path { get; private set; } 

        [JsonProperty("username")]
        public string Username { get; private set; } 

        [JsonProperty("profile_image")]
        public string ProfileImage { get; private set; } 
    }
}