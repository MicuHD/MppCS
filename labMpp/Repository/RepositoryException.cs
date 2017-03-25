using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{

    class RepositoryException : Exception
    {
        string err;
        public RepositoryException(string error)
        {
            err = error;
        }
        public string GetErrorMessage()
        {
            return err;
        }
    }
}
