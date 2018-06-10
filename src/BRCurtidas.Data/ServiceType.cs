using System.ComponentModel.DataAnnotations;
using BRCurtidas.Common;


    /*public enum ServiceType
    {
        [DisplayOptions("Curtidas")]
        Likes = 1,
        [DisplayOptions("Visualizações")]
        Views = 2,
        [DisplayOptions("Seguidores")]
        Followers = 3,
        [DisplayOptions("Inscrições")]
        Subscriptions = 4
    }*/


namespace BRCurtidas.Data
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        public string Name {get; set;}
    }
}

