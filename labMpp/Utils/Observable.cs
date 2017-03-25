using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Utils
{
    public interface IObservable<E>
    {
        void addObserver(IObserver<E> o);
        void removeObserver(IObserver<E> o);
        void notifyObservers();
    }
}
