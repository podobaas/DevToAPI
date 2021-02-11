using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class TagArticle
    {
        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("name")]
        public string Name { get; private set; } 

        [JsonProperty("bg_color_hex")]
        public string BgColorHex { get; private set; } 

        [JsonProperty("text_color_hex")]
        public string TextColorHex { get; private set; } 
    }
}