using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BRCurtidas.Common
{
    public static class ObjectExtensions
    {
        public static string SerializeToXml<T>(this T obj, Encoding encoding, XmlSerializationType serializationType = XmlSerializationType.PascalCase)
        {
            var type = typeof(T);

            var serializer = new XmlSerializer(type);
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using (var stream = new MemoryStream())
            {
                switch (serializationType)
                {
                    case XmlSerializationType.CamelCase:
                        using (var writer = new CamelCaseXmlWriter(stream, encoding))
                            serializer.Serialize(writer, obj, namespaces);
                        break;

                    case XmlSerializationType.PascalCase:
                        using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = encoding }))
                            serializer.Serialize(writer, obj, namespaces);
                        break;

                    default:
                        throw new ArgumentException("Invalid XmlSerializationType.");
                }

                return encoding.GetString(stream.ToArray());
            }
        }
    }
}
