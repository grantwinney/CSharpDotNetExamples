namespace TimeAbstractionTimers.Wrappers
{
    public class FileWrapper : IFile
    {
        public bool Exists(string? path) => File.Exists(path);
    }

    public interface IFile
    {
        bool Exists(string? path);
    }
}
