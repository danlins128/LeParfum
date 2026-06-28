using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeParfum.Exception
{
    public class InvalidLoginException : LeParfumException
    {
        public override List<string> GetErrorMessages()
        {
            List<string> errorMessage = ["Username or password invalid"];
            return errorMessage;
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}