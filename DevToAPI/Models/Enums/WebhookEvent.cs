using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevToAPI.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum WebhookEvent
    {
        [EnumMember(Value = "article_created")]
        ArticleCreated,
        
        [EnumMember(Value = "article_updated")]
        ArticleUpdated
    }
}