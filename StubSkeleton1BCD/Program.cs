
namespace Stub_skeleton_1.B_C_D {

    public class Program {

        public static void Main()
        {
            SkeletonManager manager = new(6010);
            manager.Start();

            Console.WriteLine("Skeleton started");

            Person p1 = new("Jens Jensen", 30);
            Person p2 = new("Anna Andersen", 42);

            ClientStub stub = new("127.0.0.1", 6010);

            Person oldest = stub.Oldest(p1, p2);

            Console.WriteLine("Ældste person er: " + oldest);

            Thread.Sleep(3000);
            manager.Shutdown(false);
        }

        public static void TestXML() {
            Person p1 = new("Jens Jensen", 30);

            string xml = XmlHelper.ToXml(p1);

            Console.WriteLine(xml);

            Person p2 = new();

            p2 = XmlHelper.FromXml(xml);

            Console.WriteLine(p2);
        }
    }
}