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
    }
}