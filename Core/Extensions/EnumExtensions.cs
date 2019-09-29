using System;

namespace Core.Extensions
{
    public static class EnumExtensions
    {
        public static bool OfType<T>(this Enum enumeration) where T: Enum
        {
            if (Enum.GetName(typeof(T), enumeration) != null)
            {
                return true;
            }

            return false;
        }

        public static T GetValue<T>(this Enum enumeration)
        {
            return (T) Enum.Parse(enumeration.GetType(), enumeration.ToString());
        }
    }
}
