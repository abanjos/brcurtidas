using System;
using System.Collections.Generic;
using System.Linq;

namespace BRCurtidas.Common
{
    public static class EnumUtility
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<string> AsStrings<T>()
        {
            return GetValues<T>().Select(v => v.ToString());
        }

        public static IEnumerable<string> GetNames<T>()
        {
            var type = typeof(T);

            foreach (var name in AsStrings<T>())
            {
                var field = type.GetField(name);
                var attributeType = typeof(DisplayOptionsAttribute);

                if (field.GetCustomAttributes(attributeType, false).FirstOrDefault() is DisplayOptionsAttribute attribute)
                    yield return attribute.Name;
                else
                    yield return name;
            }
        }

        public static IEnumerable<string> GetPluralizedNames<T>()
        {
            var type = typeof(T);

            foreach (var name in AsStrings<T>())
            {
                var field = type.GetField(name);
                var attributeType = typeof(DisplayOptionsAttribute);

                if (field.GetCustomAttributes(attributeType, false).FirstOrDefault() is DisplayOptionsAttribute attribute)
                    yield return attribute.PluralizedName;
                else
                    yield return name;
            }
        }
    }
}
