using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeParfum.Domain.Exceptions
{
    public class ProductExceptions : Exception
    {
        public ProductExceptions(string message) : base(message)
        {
        }
        public ProductExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}