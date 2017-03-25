using labMpp.Domain;
using labMpp.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Service
{
    interface IComandService : IObservable<Spectacol>
    {

        List<Spectacol> getSpecacol();

        bool cumparare(Spectacol spec, string nume, int nrbilete);

        List<Spectacol> cautare(string data);
    }
}
