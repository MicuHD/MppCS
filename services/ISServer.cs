using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface ISServer
    {
        void login(Personal user, ISClient client);
        void logout(Personal user, ISClient client);
        Spectacol[] getSpectacols();
        void cumparare(Cumparator cump);
    }
}
