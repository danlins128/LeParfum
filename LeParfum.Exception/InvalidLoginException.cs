using System.Net;

namespace LeParfum.Exception
{
    public class InvalidLoginException : LeParfumException
    {
        public override List<string> GetErrorMessages()
        {            
            return ["Username or password invalid"];
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}