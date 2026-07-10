namespace LeParfum.Domain.Exceptions
{
    public class UserAlreadyException : Exception
    {
        public UserAlreadyException(string message) : base(message)
        {
        }
        public UserAlreadyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}