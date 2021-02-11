using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevToAPI.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum ActionListing
    {
        [EnumMember(Value = "draft")]
        Draft,
        
        [EnumMember(Value = "bump")]
        Bump
    }
}