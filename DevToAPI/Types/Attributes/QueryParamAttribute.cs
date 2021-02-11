using System;
using DevToAPI.Helpers;

namespace DevToAPI.Types.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal sealed class QueryParamAttribute : Attribute
    {
        public string Name { get; }
        
        public QueryParamAttribute(string name)
        {
            ThrowHelper.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }
    }
}