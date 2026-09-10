using System.Xml;

namespace Stub_skeleton_1.B_C_D;

internal class XmlHelper {


    internal static string ToXml(Person person) {
        using (StringWriter sw = new()) {
            using (XmlWriter writer = XmlWriter.Create(sw)) {
                writer.WriteStartDocument();
                ToXml(person, writer);
                writer.WriteEndDocument();
            }
            return sw.ToString();
        }
    }

    internal static Person FromXml(string xml) {
        using (StringReader sr = new StringReader(xml)) {
            using (XmlReader reader = XmlReader.Create(sr)) {
                reader.MoveToContent();

                if (reader.IsStartElement("person")) {
                    return FromXml(reader);
                } else {
                    Console.WriteLine("Unexpected start element, expectet person");
                    return null;
                }
            }
        }
    }

    internal static void ToXml(Person person, XmlWriter writer) {
        writer.WriteStartElement("person");
        {
            writer.WriteElementString("name", person.Name);
            writer.WriteElementString("age", person.Age.ToString());
        }
        writer.WriteEndElement();
    }

    internal static Person FromXml(XmlReader reader) {
        Person person = new();

        reader.ReadStartElement();
        {
            person.Name = reader.ReadElementContentAsString();
            person.Age = reader.ReadElementContentAsInt();
        }
        reader.ReadEndElement();

        return person;
    }
}