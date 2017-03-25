using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Utils
{
    public interface IObserver<E>
    {
        void update(IObservable<E> observable);
    }
}
