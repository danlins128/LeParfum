using System.Net;

namespace LeParfum.Exception
{
    public abstract class LeParfumException : SystemException
    {
        public abstract string GetErrorMessage();

        public abstract HttpStatusCode GetStatusCode();           
        
    }
}
