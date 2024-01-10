namespace TimeAbstractionTimers.Wrappers
{
    public class ConsoleWrapper : IConsole
    {
        public void Clear() => Console.Clear();
        public void WriteLine(string value) => Console.WriteLine(value);
    }

    public interface IConsole
    {
        void Clear();
        void WriteLine(string value);
    }
}
