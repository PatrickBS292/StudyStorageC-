using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Stub_skeleton_1.B_C_D {
    internal class ClientStub {
        private readonly string host;
        private readonly int port;

        public ClientStub(string host, int port) {
            this.host = host;
            this.port = port;
        }

        internal void SendPerson(Person person) {
            string newPerson = XmlHelper.ToXml(person);

            Console.WriteLine("[Client] forsøger at oprette forbindelse...");

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream)) {
                Console.WriteLine("[Client] connection open");

                writer.Write(newPerson);
                writer.Flush();

                Console.WriteLine("Person sendt som XML: \n" + newPerson);

                Thread.Sleep(100);
            }
        }

        internal Person Oldest(Person p1, Person p2)
        {
            Console.WriteLine("[Client] forsøger at oprette forbindelse...");

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine("[Client] connection open");

                writer.WriteLine("Oldest");
                writer.WriteLine(XmlHelper.ToXml(p1));
                writer.WriteLine(XmlHelper.ToXml(p2));

                Console.WriteLine("[Client] Metodekald sendt: Oldest(" + p1 + ", " + p2 + ")");

                string resultXml = reader.ReadLine();
                Person oldest = XmlHelper.FromXml(resultXml);

                Console.WriteLine("[Client] Modtog resultat: " + oldest);

                return oldest;
            }
        }
    }
}