namespace TimeAbstraction
{
    // APPROACH 1: Get the current date inside the method. (untestable)
    public class BusinessOperations1
    {
        public bool IsOpenHours()
        {
            var now = DateTime.UtcNow;

            // Open 10a - 6p on Sundays
            if (now.DayOfWeek == DayOfWeek.Sunday)
                return now.Hour >= 10 && now.Hour <= 18;

            // Open 8a - 8p the rest of the week
            return now.Hour >= 8 && now.Hour <= 20;
        }
    }


    // APPROACH 2: Pass the current date to the method. (testable)
    // ... but allowing the caller to specify the current time seems weird
    public class BusinessOperations2
    {
        public bool IsOpenHours(DateTime now)
        {
            // Open 10a - 6p on Sundays
            if (now.DayOfWeek == DayOfWeek.Sunday)
                return now.Hour >= 10 && now.Hour <= 18;

            // Open 8a - 8p the rest of the week
            return now.Hour >= 8 && now.Hour <= 20;
        }
    }


    // APPROACH 3: Inject the current date into the method. (testable)
    // ... but that requires a custom wrapper around DateTime and an interface too
    public class BusinessOperations3 : IBusinessOperations3
    {
        readonly DateTime _now;

        public BusinessOperations3(IDateTime now) => _now = now.Now;

        public bool IsOpenHours()
        {
            // Open 10a - 6p on Sundays
            if (_now.DayOfWeek == DayOfWeek.Sunday)
                return _now.Hour >= 10 && _now.Hour <= 18;

            // Open 8a - 8p the rest of the week
            return _now.Hour >= 8 && _now.Hour <= 20;
        }
    }

    public interface IBusinessOperations3
    {
        bool IsOpenHours();
    }

    public class BODateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }

    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
