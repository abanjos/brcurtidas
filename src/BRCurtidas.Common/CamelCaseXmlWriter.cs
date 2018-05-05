using System;
using System.IO;
using System.Text;
using System.Xml;

namespace BRCurtidas.Common
{
    public class CamelCaseXmlWriter : XmlTextWriter
    {
        public CamelCaseXmlWriter(Stream w, Encoding encoding) : base(w, encoding) { }

        public override void WriteQualifiedName(string localName, string ns)
        {
            base.WriteQualifiedNameAsync(localName.StartAsLowerCase(), ns);
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            base.WriteStartAttribute(prefix, localName.StartAsLowerCase(), ns);
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName.StartAsLowerCase(), ns);
        }
    }
}
