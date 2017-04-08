using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labMpp.Utils;
using labMpp.Repository;

namespace labMpp.Service
{
    public class CommandService
    {
        //private List<Utils.IObserver<Spectacol>> observers;
        //private SpectacolDBRepository repoSpectacol;
        //private CumparatorDBRepository repoCumparator;


        //public CommandService(SpectacolDBRepository specrepo,CumparatorDBRepository cumprepo)
        //{
        //    repoCumparator = cumprepo;
        //    repoSpectacol = specrepo;
        //    observers = new List<Utils.IObserver<Spectacol>>();
        //}

        //public void addObserver(Utils.IObserver<Spectacol> o)
        //{
        //    observers.Add(o);
        //}

        //public List<Spectacol> cautare(string data)
        //{
        //    List<Spectacol> rez = new List<Spectacol>();
        //    foreach(var spec in repoSpectacol.findAll())
        //    {
        //        if (spec.Data.Equals(data))
        //        {
        //            rez.Add(spec);
        //        }
        //    }
        //    return rez;
        //}

        //public bool cumparare(Spectacol spec, string nume, int nrbilete)
        //{
        //    Spectacol nspec = spec;
        //    nspec.Disponibile = nspec.Disponibile - nrbilete;
        //    nspec.Vandute = nspec.Vandute + nrbilete;
        //    repoSpectacol.update(nspec.Id, nspec);
        //    repoCumparator.save(new Cumparator(nume, nrbilete, spec.Id));
        //    notifyObservers();
        //    return true;
        //}

        //public List<Spectacol> getSpecacol()
        //{
        //    return (List<Spectacol>)repoSpectacol.findAll();
        //}

        //public void notifyObservers()
        //{
        //    foreach(var obs in observers)
        //    {
        //        obs.update(this);
        //    }
        //}

        //public void removeObserver(Utils.IObserver<Spectacol> o)
        //{
        //    observers.Remove(o);
        //}

        //public Spectacol findSpectacol(int id)
        //{
        //    return repoSpectacol.findOne(id);
        //}
    }
}
