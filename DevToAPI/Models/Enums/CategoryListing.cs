using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevToAPI.Models.Enums
{
    /// <summary>
    /// The category of the listing
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum CategoryListing
    {
        [EnumMember(Value = "cfp")]
        Cpf,
        
        [EnumMember(Value = "forhire")]
        Forhire,
        
        [EnumMember(Value = "collabs")]
        Collabs,
        
        [EnumMember(Value = "education")]
        Education,
        
        [EnumMember(Value = "jobs")]
        Jobs,
        
        [EnumMember(Value = "mentors")]
        Mentors,
        
        [EnumMember(Value = "products")]
        Products,
        
        [EnumMember(Value = "mentees")]
        Mentees,
        
        [EnumMember(Value = "forsale")]
        Forsale,
        
        [EnumMember(Value = "events")]
        Events,
        
        [EnumMember(Value = "misc")]
        Misc
    }
}