using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace BRCurtidas.PagSeguro
{
    [XmlType("Checkout")]
    public class CheckoutRequest
    {
        public CheckoutRequest()
        {
            Documents = new List<Document>();
            Items = new List<Item>();
        }

        public Sender Sender { get; set; }

        public List<Document> Documents { get; set; }

        public Currency Currency { get; set; }

        public List<Item> Items { get; set; }

        public string RedirectUrl { get; set; }

        [XmlIgnore]
        public decimal ExtraAmount { get; set; }

        [XmlElement("ExtraAmount")]
        public string ExtraAmountString
        {
            get { return ExtraAmount.ToString("F2", CultureInfo.InvariantCulture); }
            set { ExtraAmount = Convert.ToDecimal(value); }
        }

        public string Reference { get; set; }

        public Receiver Receiver { get; set; }
    }
}
