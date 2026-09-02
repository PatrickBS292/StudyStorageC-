public class Actor
{
    public string Name { get; set; }
    public string Role { get; set; }
    public int Year { get; set; }
    public string Nationality { get; set; }

    public override string ToString()
    {
       return $"Name: {Name}, Role: {Role}, Year: {Year}, Nationality: {Nationality}";
    }
}