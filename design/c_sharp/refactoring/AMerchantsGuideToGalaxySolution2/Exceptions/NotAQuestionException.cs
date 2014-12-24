using System;

namespace Exceptions
{
    public class NotAQuestionException : Exception
    {
        public NotAQuestionException(string userMessage, string inner) : base(inner)
        {
            Console.WriteLine(userMessage);
        }
    }
}
