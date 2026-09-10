using System;
using System.Threading;

namespace Stub_skeleton_1.B_C_D {

    public class Program {

        public static void Main() {
            SkeletonManager manager = new(6010);
            manager.Start();

            Console.WriteLine("Skeleton started");

            Person p = new("Jens Jensen", 30);
            Console.WriteLine("Sending person: " + p);

            ClientStub stub = new("127.0.0.1", 6010);
            stub.SendPerson(p);
            Console.WriteLine("Person send");

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