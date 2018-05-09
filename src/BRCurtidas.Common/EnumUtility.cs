using System;
using System.Collections.Generic;
using System.Linq;

namespace BRCurtidas.Common
{
    [AttributeUsage(AttributeTargets.Enum)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        public EnumDescriptionAttribute(string name, string culture)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Culture = culture ?? throw new ArgumentNullException(nameof(culture));
        }

        public string Name { get; set; }

        public string Culture { get; set; }
    }

    public static class EnumUtility
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<string> GetDescriptions<T>()
        {
            return GetValues<T>().Select(v => v.ToString());
        }
    }
}
