using System.Xml.Linq;

List<Actor> actors = new List<Actor>();

XDocument document = XDocument.Load("actors.xml");

foreach (XElement actorElement in document.Descendants("actor"))
{
    // read values safely using null-conditional and defaults
    string name = actorElement.Element("name")?.Value;
    string role = actorElement.Element("role")?.Value;
    string yearText = actorElement.Element("year")?.Value;
    string nationality = actorElement.Attribute("nationality")?.Value ?? actorElement.Element("nationality")?.Value;

    int year = int.TryParse(yearText, out var y) ? y : 0;

    Actor actor = new Actor
    {
        Name = name ?? string.Empty,
        Role = role ?? string.Empty,
        Year = year,
        Nationality = nationality ?? string.Empty
    };

    actors.Add(actor);
}

foreach (Actor actor in actors)
{
    Console.WriteLine(actor);
}

XDocument outputDocument = new XDocument(new XElement("actors"));

foreach (Actor actor in actors)
{
    outputDocument.Root.Add(
        new XElement("actor",
            new XAttribute("nationality", actor.Nationality ?? string.Empty),
            new XElement("name", actor.Name),
            new XElement("role", actor.Role),
            new XElement("year", actor.Year)
        )
    );
}

outputDocument.Save("actors-output.xml");