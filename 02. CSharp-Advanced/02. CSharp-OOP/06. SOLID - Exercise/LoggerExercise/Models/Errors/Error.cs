using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;
using System;

namespace LoggerExercise.Models.Errors
{
    public class Error : IPathManager
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            DateTime = dateTime;
            Message = message;
            Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }


    }
}
