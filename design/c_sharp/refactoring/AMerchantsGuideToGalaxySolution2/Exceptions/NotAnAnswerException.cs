using System;

namespace Exceptions
{
    public class NotAnAnswerException:Exception
    {
        public NotAnAnswerException(string userMessage, string inner) : base(inner)
        {
            Console.WriteLine(userMessage);
        }
    }
}
