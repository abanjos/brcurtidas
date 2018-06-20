using System.Collections.Generic;

namespace BRCurtidas.Data
{
    public class Product
    {
        public int Id { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public decimal Price { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public ScopedServiceType ScopedServiceType { get; set; }

        public string Title { get; set; }
    }
}