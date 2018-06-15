using System.ComponentModel.DataAnnotations;
using BRCurtidas.Common;

namespace BRCurtidas.Data
{
    public class ServiceScope
    {
        [Key]
        public int Id { get; set; }

        public string Name {get; set;}
    }
}
