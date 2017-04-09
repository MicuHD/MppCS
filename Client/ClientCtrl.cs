using model;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    

    public class ClientCtrl : ISClient
    {

        public event EventHandler<UserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly ISServer server;
        private Personal currentUser;

        public ClientCtrl(ISServer server)
        {
            this.server = server;
            currentUser = null;
        }

        public void login(string userame, string pass)
        {
            Personal user = new Personal(userame, pass);
            server.login(user,this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
        }

        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.logout(currentUser, this);
            currentUser = null;
        }
        public List<Spectacol> getSpectacol()
        {
            List<Spectacol> spectacols = new List<Spectacol>();
            Spectacol[] specs = server.getSpectacols();
            foreach (var spec in specs)
            {
                spectacols.Add(spec);
            }
            return spectacols;
        }

        public List<Spectacol> cautare(string data)
        {
            List<Spectacol> specs = getSpectacol();
            List<Spectacol> result = new List<Spectacol>();
            foreach(Spectacol sp in specs)
            {
                if (sp.Data.Equals(data))
                {
                    result.Add(sp);
                }
            }
            return result;
        }

        public void cumparare(Spectacol spec,string nume,int nrbilete)
        {
            server.cumparare(new Cumparator(nume, nrbilete, spec.Id));
        }

        public void TicketSold(Spectacol spec)
        {
            Console.Out.WriteLine("Intra in sold ticket");
            UserEventArgs userArgs = new UserEventArgs(UserEvent.SoldTicket, spec);
            OnUserEvent(userArgs);
        }

        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if (updateEvent == null) return;
            Console.WriteLine("Update Event called");
            updateEvent(this, e);
            
        }

    }
}
