using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SerializeToXmlMethod;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
        StringBuilder stringBuilder = new StringBuilder();

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = omitDeclaration,
            Encoding = new UTF8Encoding(false),
            Indent = true,
        };

        using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture);

        using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            try
            {
                xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
            }
            catch (Exception)
            {

                throw;
            }
        }

        return stringBuilder.ToString();
    }
}