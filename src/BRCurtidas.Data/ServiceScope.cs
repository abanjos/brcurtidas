using BRCurtidas.Common;

namespace BRCurtidas.Data
{
    public enum ServiceScope
    {
        [DisplayOptions("Brasileiro", "Brasileiros")]
        National = 1,
        [DisplayOptions("Internacional", "Internacionais")]
        International = 2
    }
}
