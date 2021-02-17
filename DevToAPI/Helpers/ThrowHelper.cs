using System;

namespace DevToAPI.Helpers
{
    internal static class ThrowHelper
    {
        public static void ThrowIfLessThanOne(int? val, string name)
        {
            if (val < 1)
            {
                throw new ArgumentOutOfRangeException(name, $"{name} must be greater than 0");
            }
        }
        
        public static void ThrowIfLessThanOne(long? val, string name)
        {
            if (val < 1)
            {
                throw new ArgumentOutOfRangeException(name, $"{name} must be greater than 0");
            }
        }
        
        public static void ThrowIfOutOfRange(int val, int min, int max, string name)
        {
            if (val < min || val > max)
            {
                throw new ArgumentOutOfRangeException(name, $"{name} size must be in the range from {min} to {max}");
            }
        }

        public static void ThrowIfNullOrEmpty(string val, string name)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentNullException(name);
            }
        }
        
        public static void ThrowIfNull(object val, string name)
        {
            if (val == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}