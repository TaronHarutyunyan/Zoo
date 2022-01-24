using System;

namespace Zoo
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string s)
        {
            Console.WriteLine("ERROR!!!");
            FileManagers.ErrorWriter(s);
        }
    }
}
