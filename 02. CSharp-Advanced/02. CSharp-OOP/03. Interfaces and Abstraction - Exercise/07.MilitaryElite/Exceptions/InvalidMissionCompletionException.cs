using System;
namespace _07.MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string INV_MISS_COMP_EXC = "Invalid mission completion";

        public InvalidMissionCompletionException()
            :base(INV_MISS_COMP_EXC)
        {
        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {
        }
    }
}
