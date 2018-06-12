using System;

namespace ContactsApp.Exceptions
{
    public class InvalidNumberFormatException : Exception
    {
        public InvalidNumberFormatException() : base("Invalid number")
        {
        }

        public InvalidNumberFormatException(string message) : base(message)
        {
        }
    }
}