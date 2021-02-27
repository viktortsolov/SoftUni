using System;
namespace _07.MilitaryElite.Exceptions
{
    public class InvalidMissionException : Exception
    {
        private const string INV_MISS_EXC = "Invalid mission state!";

        public InvalidMissionException()
            :base(INV_MISS_EXC)
        {
        }

        public InvalidMissionException(string message)
            : base(message)
        {
        }
    }
}
