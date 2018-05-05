using System;
using System.IO;
using System.Xml.Serialization;

namespace BRCurtidas.Common
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidUrl(this string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri _uri);
        }

        public static T XmlDeserialize<T>(this string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(xml))
                using (var xmlReader = new CamelCaseXmlReader(stringReader))
                    return (T)serializer.Deserialize(xmlReader);
        }

        public static string StartAsLowerCase(this string name)
        {
            if (name.Length == 0) return name;
            if (Char.IsLower(name[0])) return name;
            if (name.Length == 1) return name.ToLower();

            var letters = name.ToCharArray();
            letters[0] = Char.ToLower(letters[0]);

            return new string(letters);
        }

        public static string StartAsUpperCase(this string name)
        {
            if (name.Length == 0) return name;
            if (Char.IsUpper(name[0])) return name;
            if (name.Length == 1) return name.ToUpper();

            var letters = name.ToCharArray();
            letters[0] = Char.ToUpper(letters[0]);

            return new string(letters);
        }
    }
}
