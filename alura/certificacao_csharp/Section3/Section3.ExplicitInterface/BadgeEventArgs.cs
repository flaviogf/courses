using System;

namespace Section3.ExplicitInterface
{
    public class BadgeEventArgs: EventArgs
    {
        public BadgeEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
