using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions
{
    public class ItemAlreadyExistException : Exception
    {
        public ItemAlreadyExistException() : base()
        {

        }
        public ItemAlreadyExistException(string message) : base(message)
        {

        }
        public ItemAlreadyExistException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
