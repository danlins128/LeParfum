using System.Net;

namespace LeParfum.Exception
{
    public abstract class LeParfumException : SystemException
    {
        public abstract GetErrorMessages()
        {
            return List<String>;
        }
        public abstract GetStatusCode()
        {
            return HttpStatusCode;
        }
    }
}
