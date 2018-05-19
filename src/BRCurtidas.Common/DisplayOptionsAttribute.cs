using System;

namespace BRCurtidas.Common
{
    public sealed class DisplayOptionsAttribute : Attribute
    {
        public DisplayOptionsAttribute(string name, string pluralizedName)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PluralizedName = pluralizedName ?? throw new ArgumentNullException(nameof(pluralizedName));
        }

        public DisplayOptionsAttribute(string name)
            : this(name, name)
        {
        }

        public string Name { get; private set; }

        public string PluralizedName { get; private set; }
    }
}
