/*
Console.WriteLine("Hvad er din score?");
String score = Console.ReadLine();
int parsedScore = int.Parse(score);
if (parsedScore >= 50) {
    Console.WriteLine("Du bestod!");
} else {
    Console.WriteLine("Du bestod ikke.");
}
*/

Console.WriteLine("Hvor gammel er du?");
string age = Console.ReadLine();
int ageAsInt = int.Parse(age);
if (ageAsInt < 13)
{
    Console.WriteLine("Du er et barn.");
}
else if (ageAsInt >= 13 && ageAsInt < 18)
{
    Console.WriteLine("Du er teenager.");
}
else if (ageAsInt >= 18)
{
    Console.WriteLine("Du er en voksen.");
}
