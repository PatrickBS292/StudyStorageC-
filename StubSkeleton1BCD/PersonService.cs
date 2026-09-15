
namespace Stub_skeleton_1.B_C_D
{
    internal class PersonService
    {
        internal Person Oldest(Person p1, Person p2)
        {
            return (p1.Age >= p2.Age) ? p1 : p2;
        }
    }
}