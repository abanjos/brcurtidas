using System.Xml.Serialization;

namespace BRCurtidas.PagSeguro
{
    public class Sender
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Phone Phone { get; set; }

        public string Ip { get; set; }
    }
}
