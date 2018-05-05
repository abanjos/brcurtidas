using System.Xml.Serialization;

namespace BRCurtidas.PagSeguro
{
    public class Item
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }
    }
}
