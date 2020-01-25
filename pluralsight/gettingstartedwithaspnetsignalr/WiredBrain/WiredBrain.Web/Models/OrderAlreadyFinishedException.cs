using System;
using System.Runtime.Serialization;

namespace WiredBrain.Web.Models
{
    [Serializable]
    public class OrderAlreadyFinishedException : Exception
    {
        public OrderAlreadyFinishedException() : base("This order was finished and can't be finished already")
        {
        }

        public OrderAlreadyFinishedException(string message) : base(message)
        {
        }

        public OrderAlreadyFinishedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderAlreadyFinishedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}