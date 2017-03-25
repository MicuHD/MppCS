using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Validators
{
    public class ValidatorException : Exception
    {
        string err;
        public ValidatorException(string error)
        {
            err = error;
        }
        public string GetErrorMessage()
        {
            return err;
        }
    }
}
