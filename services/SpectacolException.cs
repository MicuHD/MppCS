using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class SpectacolException : Exception
    {
        public SpectacolException():base() { }

        public SpectacolException(String msg) : base(msg) { }

        public SpectacolException(String msg, Exception ex) : base(msg, ex) { }

    }
}
