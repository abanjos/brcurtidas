using System.ComponentModel.DataAnnotations;

namespace BRCurtidas.Data
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}