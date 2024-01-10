using TimeAbstractionTimers.Wrappers;

namespace TimeAbstractionTimers
{
    public class TimerSamples : ITimerSamples
    {
        private readonly TimeProvider _timeProvider;
        private readonly IConsole _console;
        private readonly IFile _file;

        public TimerSamples(TimeProvider timeProvider, IConsole console, IFile file)
        {
            _timeProvider = timeProvider;
            _console = console;
            _file = file;
        }

        public void StartTimers()
        {
            _timeProvider.CreateTimer(PrintTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            _timeProvider.CreateTimer(CheckFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        public void PrintTime(object? _)
        {
            //Thread.Sleep(10);

            var today = _timeProvider.GetLocalNow();
            var message = (today.DayOfWeek == DayOfWeek.Friday && today.Hour >= 17)
                ?
                    $"""
                    TGIF!!!

                    It's {_timeProvider.GetLocalNow():hh:mm tt}... go home!
                    """
                :
                    $"""
                    THE CURRENT TIME:
                    ================
                    🕒 {_timeProvider.GetLocalNow():hh:mm:ss tt}
                    ================
                    """;

            _console.Clear();
            _console.WriteLine(message);
        }

        public void CheckFile(object? _)
        {
            // Let's pretend FileSystemWatcher doesn't exist...
            var isNewOrderFound = _file.Exists("incoming_order_to_process.xml");
            
            if (isNewOrderFound)
            {
                // Now what? Process it somehow? Call an API?
            }
        }
    }

    public interface ITimerSamples
    {
        void StartTimers();
    }
}
