using BRCurtidas.Common;

namespace BRCurtidas.Data
{
    public enum ServiceType
    {
        [DisplayOptions("Curtidas")]
        Likes = 1,
        [DisplayOptions("Visualizações")]
        Views = 2,
        [DisplayOptions("Seguidores")]
        Followers = 3,
        [DisplayOptions("Inscrições")]
        Subscriptions = 4
    }
}
