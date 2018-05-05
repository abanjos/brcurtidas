using System.IO;
using System.Linq;
using System.Xml;

namespace BRCurtidas.Common
{
    public class CamelCaseXmlReader : XmlTextReader
    {
        public CamelCaseXmlReader(TextReader input) : base(input) { }

        public override string this[string name, string namespaceURI]
        {
            get { return base[NameTable.Add(name.StartAsLowerCase()), namespaceURI]; }
        }

        public override string LocalName
        {
            get
            {
                var nodeTypes = new[] { XmlNodeType.Element, XmlNodeType.EndElement, XmlNodeType.Attribute };

                if (nodeTypes.Contains(base.NodeType))
                    return NameTable.Add(base.LocalName.StartAsUpperCase());

                return base.LocalName;
            }
        }

        public override string Name
        {
            get
            {
                if (base.Name.IndexOf(":") == -1)
                {
                    return NameTable.Add(base.Name.StartAsUpperCase());
                }
                else
                {
                    var name = base.Name.Substring(0, base.Name.IndexOf(":") + 1);
                    name += NameTable.Add((base.Name.Substring(base.Name.IndexOf(":") + 1)).StartAsUpperCase());
                    return NameTable.Add(name);
                }
            }
        }

        public override bool MoveToAttribute(string localName, string namespaceURI)
        {
            return base.MoveToAttribute(NameTable.Add(localName.StartAsLowerCase()), namespaceURI);
        }
    }
}
