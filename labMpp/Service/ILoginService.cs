using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Service
{
    public interface ILoginService<E>
    {
        E Login(String user, String pass);
    }
}
