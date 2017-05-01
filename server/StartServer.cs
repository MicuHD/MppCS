using System;
using System.Net.Sockets;

using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace server
{
    using server;
    using persistance;
    using services;
    using System.Collections;

    class StartServer
    {
        static void Main(string[] args)
        {

            //PersonalDBRepository userRepo = new PersonalDBRepository();
            //CumparatorDBRepository cumpRepo = new CumparatorDBRepository();
            //SpectacolDBRepository specRepo = new SpectacolDBRepository();
            //ISServer serviceImpl = new ServerImpl(userRepo,specRepo,cumpRepo);

            //// IChatServer serviceImpl = new ChatServerImpl();
            //SerialChatServer server = new SerialChatServer("127.0.0.1", 55555, serviceImpl);
            //server.Start();
            //Console.WriteLine("Server started ...");
            ////Console.WriteLine("Press <enter> to exit...");
            //Console.ReadLine();

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);

            PersonalDBRepository userRepo = new PersonalDBRepository();
            CumparatorDBRepository cumpRepo = new CumparatorDBRepository();
            SpectacolDBRepository specRepo = new SpectacolDBRepository();
            var server = new ServerImpl(userRepo, specRepo, cumpRepo);
            //var server = new ChatServerImpl();
            RemotingServices.Marshal(server, "Chat");
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(ChatServerImpl), "Chat",
            //    WellKnownObjectMode.Singleton);

            // the server will keep running until keypress.
            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();


        }
    }

    //public class SerialChatServer: ConcurrentServer 
    //{
    //    private ISServer server;
    //    private ClientWorker worker;
    //    public SerialChatServer(string host, int port, ISServer server) : base(host, port)
    //    {
    //        this.server = server;
    //        Console.WriteLine("SerialChatServer...");
    //    }
    //    protected override Thread createWorker(TcpClient client)
    //    {
    //        worker = new ClientWorker(server, client);
    //        return new Thread(new ThreadStart(worker.run));
    //    }
    //}
    
}
