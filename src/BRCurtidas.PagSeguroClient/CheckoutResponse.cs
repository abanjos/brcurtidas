using System;
using System.Xml.Serialization;

namespace BRCurtidas.PagSeguro
{
    [XmlType("Checkout")]
    public class CheckoutResponse
    {
        public string Code { get; set; }

        public DateTime Date { get; set; }
    }
}
