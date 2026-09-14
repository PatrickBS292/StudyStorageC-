using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Linq.Expressions;

namespace Stub_skeleton_1.B_C_D {
    internal class SkeletonWorker {
        private readonly SkeletonManager manager;
        private readonly Socket connection;

        private readonly PersonService service = new();

        private bool stop;
        private Thread thread;

        internal SkeletonWorker(SkeletonManager manager, Socket connection) {
            this.manager = manager;
            this.connection = connection;
        }

        internal void Start() {
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            Console.WriteLine("SkeletonWorker: New connection from " + connection.RemoteEndPoint);

            try
            {
                using (NetworkStream stream = new(connection))
                using (StreamWriter writer = new(stream) { AutoFlush = true })
                using (StreamReader reader = new(stream))
                {

                    string methodName = reader.ReadLine();

                    switch (methodName)
                    {
                        case "Oldest":
                            {
                                Person p1 = XmlHelper.FromXml(reader.ReadLine());
                                Person p2 = XmlHelper.FromXml(reader.ReadLine());

                                Console.WriteLine($"SkeletonWorker: kalder Oldest({p1}, {p2})");

                                Person result = service.Oldest(p1, p2);

                                writer.WriteLine(XmlHelper.ToXml(result));

                                Console.WriteLine("SkeletonWorker: resultat sendt: " + result);
                                break;
                            }
                        default:
                            Console.WriteLine("SkeletonWorker: ukendt metode: " + methodName);
                            break;
                    }
                }
            }
            catch (IOException)
            {

            }
            manager.Remove(this);

            Console.WriteLine("Terminated");
        }

        public void Shutdown(bool waitForTermination = false) {
            Console.WriteLine("Shutdown requested");

            stop = true;

            if (waitForTermination)
                thread.Join();
        }
    }
}
