using LoggerExercise.Models.Contracts;
using System.IO;

namespace LoggerExercise.Models.PathManagement
{
    class PathManager : IPathManager
    {
        private const string PATH_DELIMITER = "\\";

        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        private PathManager()
        {
            this.currentPath = this.GetCurrentPath();
        }
        public PathManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath
            => this.currentPath + PATH_DELIMITER + this.folderName;


        public string CurrentFilePath
            => this.CurrentDirectoryPath + PATH_DELIMITER + this.fileName;

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory(); 
        }
    }
}
