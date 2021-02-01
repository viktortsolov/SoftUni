using LoggerExercise.Models.PathManagement;
using System;

namespace LoggerExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            PathManager pathManager = new PathManager("logs", "log.txt");

            Console.WriteLine(pathManager.CurrentDirectoryPath + Environment.NewLine + pathManager.CurrentFilePath);
        }
    }
}
