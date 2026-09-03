
//Console.WriteLine("Hvad er din alder?");
//string age = Console.ReadLine();
//int ageInInt = int.Parse(age);
//Console.WriteLine("Du er " + ageInInt + " år gammel.");

Console.WriteLine("Hvor gammel er du?");
string age = Console.ReadLine();
int ageInInt = int.Parse(age);
if (ageInInt >= 18 )
{
    Console.WriteLine("Du er myndig");
} 
else
{
    Console.WriteLine("Du er ikke myndig");
}