using System.Net;

namespace LeParfum.Exception
{
    public abstract class LeParfumException : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
