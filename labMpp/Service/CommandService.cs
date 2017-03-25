using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labMpp.Domain;
using labMpp.Utils;
using labMpp.Repository;

namespace labMpp.Service
{
    public class CommandService : IComandService
    {
        private List<Utils.IObserver<Spectacol>> observers;
        private SpectacolDBRepository repoSpectacol;
        private CumparatorDBRepository repoCumparator;


        public CommandService(SpectacolDBRepository specrepo,CumparatorDBRepository cumprepo)
        {
            repoCumparator = cumprepo;
            repoSpectacol = specrepo;
            observers = new List<Utils.IObserver<Spectacol>>();
        }

        public void addObserver(Utils.IObserver<Spectacol> o)
        {
            observers.Add(o);
        }

        public List<Spectacol> cautare(string data)
        {
            throw new NotImplementedException();
        }

        public bool cumparare(Spectacol spec, string nume, int nrbilete)
        {
            throw new NotImplementedException();
        }

        public List<Spectacol> getSpecacol()
        {
            throw new NotImplementedException();
        }

        public void notifyObservers()
        {
            foreach(var obs in observers)
            {
                obs.update(this);
            }
        }

        public void removeObserver(Utils.IObserver<Spectacol> o)
        {
            observers.Remove(o);
        }
    }
}
