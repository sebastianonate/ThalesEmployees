using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Core.Application.Exceptions
{
    public class TooManyRequestsException : CustomException
    {
        public TooManyRequestsException(string message)
            : base(message, null, HttpStatusCode.TooManyRequests)
        {
        }
    }
}
