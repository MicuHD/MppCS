using System;
using System.Net.Sockets;

using System.Threading;

namespace server
{
    using ServerTemplate;
    using server;
    using persistance;
    using services;
    using networking;

    class StartServer
    {
        static void Main(string[] args)
        {

            PersonalDBRepository userRepo = new PersonalDBRepository();
            CumparatorDBRepository cumpRepo = new CumparatorDBRepository();
            SpectacolDBRepository specRepo = new SpectacolDBRepository();
            ISServer serviceImpl = new ServerImpl(userRepo,specRepo,cumpRepo);

            // IChatServer serviceImpl = new ChatServerImpl();
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55556, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
    }

    public class SerialChatServer: ConcurrentServer 
    {
        private ISServer server;
        private ClientWorker worker;
        public SerialChatServer(string host, int port, ISServer server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
    
}
