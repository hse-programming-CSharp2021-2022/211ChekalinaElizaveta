using System;
using System.Runtime.Serialization;

namespace PizzaStuff
{
    public class PizzaException : Exception { 
   
        public PizzaException()
        {
        }

        protected PizzaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PizzaException(string? message) : base(message)
        {
        }

        public PizzaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
