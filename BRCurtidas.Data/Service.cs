using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRCurtidas.Data
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ServiceCategory Category { get; set; }

        public string Description { get; set; }

        public SocialNetwork SocialNetwork { get; set; }

        public PaymentType PaymentType { get; set; }

        public ServiceType Type { get; set; }

        public decimal Price { get; set; }

        public bool Enabled { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
