using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRCurtidas.Data
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public virtual User User { get; set; }

        public string SocialNetworkProfile { get; set; }

        public virtual Product Product { get; set; }

        public virtual Payment Payment { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }
    }
}