using LoggerExercise.Models.Contracts;

namespace LoggerExercise.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;
        public string Path { get; }

        public long Size { get; }

        public string Write(ILayout layout, IPathManager error)
        {
            throw new System.NotImplementedException();
        }
    }
}
