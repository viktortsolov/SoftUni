namespace LoggerExercise.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }

        long Size { get; }

        string Write(ILayout layout, IPathManager error);
    }
}
