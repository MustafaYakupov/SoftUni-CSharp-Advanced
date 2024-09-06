using System.Xml.Linq;
using System.Xml.Serialization;
using XMLDemo;

//string xmlString = @"<?xml version=""1.0""?>
//<library name=""Developer's Library"">
// <book>
// <title>Professional C# and .NET</title>
// <author>Christian Nagel</author>
// <isbn>978-0-470-50225-9</isbn>
// </book>
// <book>
// <title>
//    Teach Yourself XML in 10 Minutes
// </title>
// <author>Andrew H. Watt</author>
// <isbn>978-0-672-32471-0</isbn>
// </book>
//</library>";

//XDocument doc = XDocument.Parse(xmlString);

//doc.Root
//    .Descendants()
//    .First()
//    .SetElementValue("issueDate", "2024-07-25");

//doc.Root
//    .Descendants()
//    .First()
//    .SetAttributeValue("issueDate", "2024-07-25");

//doc.Save("test.xml");

//Console.WriteLine(doc.Root
//    .Descendants()
//    .First()
//    .Elements()
//    .First(e => e.Name == "author").Value);

var family = new Family()
{
    FamilyName = "Petrovi",
    Members = new Person[]
    {
        new Person()
        {
            Name = "Petar",
            Age = 20,
        },

        new Person()
        {
            Name = "Penka",
            Age = 18,
        }
    }
};

XmlSerializer serializer = new XmlSerializer(typeof(Family));

using (StreamWriter writer = new StreamWriter("family.xml"))
{
    serializer.Serialize(writer, family);
}