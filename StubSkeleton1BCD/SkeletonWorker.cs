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

        private void Run() {
            Console.WriteLine("SkeletonWorker: New connection from " + connection.RemoteEndPoint);

            try {
                using (NetworkStream stream = new(connection))
                using (StreamWriter writer = new(stream))
                using (StreamReader reader = new(stream)) {

                    string xmlLine = reader.ReadLine();
                    Person person = new();
                    person = XmlHelper.FromXml(xmlLine);

                    Console.WriteLine(person);
                }
            } catch (IOException) {

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
