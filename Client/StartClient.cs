using networking.server;
using services;
using System;
using System.Windows.Forms;

namespace Client
{
    class StartClient
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //IChatServer server=new ChatServerMock();          
            ISServer server = new ServerProxy("127.0.0.1", 55555);
            ClientCtrl ctrl = new ClientCtrl(server);
            Login win = new Login(ctrl);
            Application.Run(win);
        }


    }
}
