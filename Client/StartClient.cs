using networking.server;
using services;
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace Client
{
    class StartClient
    {
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            ////IChatServer server=new ChatServerMock();          
            //ISServer server = new ServerProxy("127.0.0.1", 55555);
            //ClientCtrl ctrl = new ClientCtrl(server);
            //Login win = new Login(ctrl);
            //Application.Run(win);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //IChatServer server=new ChatServerMock();          
            /* IChatServer server = new ChatServerProxy("127.0.0.1", 55555);
             ChatClientCtrl ctrl=new ChatClientCtrl(server);
             LoginWindow win=new LoginWindow(ctrl);
             Application.Run(win);*/
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 0;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);
            ISServer server =
                (ISServer)Activator.GetObject(typeof(ISServer), "tcp://localhost:55555/Chat");

            ClientCtrl ctrl = new ClientCtrl(server);
            Login win = new Login(ctrl);
            Application.Run(win);


        }


    }
}
