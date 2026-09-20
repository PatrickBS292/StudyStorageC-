

Console.WriteLine("Hvad er dit brugernavn?");

string userName = Console.ReadLine();

Console.WriteLine("Hvad er din alder?");

int userAge = int.Parse(Console.ReadLine());

if (userName == "Patrick" && userAge >= 18)
{
    Console.WriteLine("Adgang Tilladt.");
}
else
{
    Console.WriteLine("Adgang Ikke Tilladt.");
}