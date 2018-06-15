using System.ComponentModel.DataAnnotations;

namespace BRCurtidas.Data
{
    public class ServiceScope
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}