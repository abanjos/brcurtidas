using System;
using System.Linq;

namespace BRCurtidas.Common
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            var type = value.GetType();
            var name = value.ToString();
            var field = type.GetField(value.ToString());
            var attributeType = typeof(DisplayOptionsAttribute);

            if (field.GetCustomAttributes(attributeType, false).FirstOrDefault() is DisplayOptionsAttribute attribute)
                return attribute.Name;
            else
                return name;
        }

        public static string GetPluralizedName(this Enum value)
        {
            var type = value.GetType();
            var name = value.ToString();
            var field = type.GetField(value.ToString());
            var attributeType = typeof(DisplayOptionsAttribute);

            if (field.GetCustomAttributes(attributeType, false).FirstOrDefault() is DisplayOptionsAttribute attribute)
                return attribute.PluralizedName;
            else
                return name;
        }
    }
}
