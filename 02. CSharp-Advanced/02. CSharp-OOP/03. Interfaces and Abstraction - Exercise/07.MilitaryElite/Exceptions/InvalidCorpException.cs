using System;
namespace _07.MilitaryElite.Exceptions
{
    public class InvalidCorpException : Exception
    {
        private const string DEF_MESS_EXC = "Invalid corps!";
        public InvalidCorpException()
            :base(DEF_MESS_EXC)
        {
        }

        public InvalidCorpException(string message)
            : base(message)
        {
        }
    }
}
