using System.Xml.Serialization;

namespace BRCurtidas.PagSeguro
{
    public class Document
    {
        public DocumentType Type { get; set; }

        public string Value { get; set; }
    }
}
