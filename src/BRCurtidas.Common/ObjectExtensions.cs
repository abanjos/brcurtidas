using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BRCurtidas.Common
{
    public static class ObjectExtensions
    {
        public static string SerializeToXml<T>(this T obj, Encoding encoding)
        {
            var type = typeof(T);

            var serializer = new XmlSerializer(type);
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using (var stream = new MemoryStream())
            {
                using (var writer = new CamelCaseXmlWriter(stream, encoding))
                    serializer.Serialize(writer, obj, namespaces);

                return encoding.GetString(stream.ToArray());
            }
        }
    }
}
