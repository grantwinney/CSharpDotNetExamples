namespace TimeAbstraction
{
    // NEW APPROACH: Use the new TimeProvider.
    public class BusinessOperations : IBusinessOperations
    {
        private readonly TimeProvider _now;

        public BusinessOperations(TimeProvider now) => _now = now;

        public bool IsOpenHours()
        {
            var utc = _now.GetUtcNow();

            // Open 10a - 6p on Sundays
            if (utc.DayOfWeek == DayOfWeek.Sunday)
                return utc.Hour >= 10 && utc.Hour <= 18;

            // Open 8a - 8p the rest of the week
            return utc.Hour >= 8 && utc.Hour <= 20;
        }
    }

    public interface IBusinessOperations
    {
        bool IsOpenHours();
    }
}
