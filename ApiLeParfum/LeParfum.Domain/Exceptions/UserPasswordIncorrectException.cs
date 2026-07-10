using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeParfum.Domain.Exceptions
{
    public class UserPasswordIncorrectException : Exception
    {
        public UserPasswordIncorrectException(string message) : base(message)
        {
        }
        public UserPasswordIncorrectException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}