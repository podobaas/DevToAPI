using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class ProfileImage
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("image_of")]
        public string ImageOf { get; private set; } 

        [JsonProperty("profile_image")]
        public string Image { get; private set; } 

        [JsonProperty("profile_image_90")]
        public string ImageSmall { get; private set; } 
    }
}