
using System.Net.Sockets;
using System.Net;

namespace Stub_skeleton_1.B_C_D {
    internal class SkeletonManager {
        private Thread thread;
        private bool stop, waitForTermination;

        private readonly List<SkeletonWorker> workers;
        private readonly int port;

        internal SkeletonManager(int port) {
            this.port = port;

            stop = false;
            workers = new List<SkeletonWorker>();
            waitForTermination = false;
        }

        internal void Start() {
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run() {
            try {
                TcpListener server = new TcpListener(IPAddress.Any, port);
                server.Start();

                Console.WriteLine("Server online");

                while (!stop) {
                    if (server.Pending()) {
                        Socket connection = server.AcceptSocket();
                        SkeletonWorker worker = new(this, connection);
                        workers.Add(worker);
                        worker.Start();
                    } else
                        Thread.Sleep(100);


                }
                foreach (SkeletonWorker worker in workers) {
                    worker.Shutdown(waitForTermination);
                }
                Console.WriteLine("Server shutdown");
            } catch (IOException) {
                Console.WriteLine("I/O error");
            }
        }
        public void Shutdown(bool waitForTermination) {
            Console.WriteLine("Shutdown requested");

            this.waitForTermination = waitForTermination;

            stop = true;

            if (waitForTermination)
                thread.Join();
        }

        internal void Remove(SkeletonWorker worker) {
            workers.Remove(worker);
        }
    }
}

