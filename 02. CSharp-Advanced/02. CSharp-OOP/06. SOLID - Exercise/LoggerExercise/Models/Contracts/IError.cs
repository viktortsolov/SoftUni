using System;

using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Contracts
{
    public interface IPathManager
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}