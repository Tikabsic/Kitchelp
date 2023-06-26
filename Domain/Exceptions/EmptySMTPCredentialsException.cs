using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EmptySMTPCredentialsException : Exception
    {
        public EmptySMTPCredentialsException() : base("You must define credentials in SMTPClient")
        {

        }
    }
}
