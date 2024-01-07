using Microsoft.Extensions.Time.Testing;
using TimeAbstraction;

namespace TimeAbstractionTests
{
    [TestFixture]
    public class BusinessOperationsTests
    {
        private FakeTimeProvider fake;
        private BusinessOperations busOp;

        [SetUp]
        public void Setup()
        {
            fake = new();
            busOp = new(fake);
        }

        [Category("Monday Hours")]
        [TestCase(7, false, TestName = "Closed at 7am")]
        [TestCase(8, true, TestName = "Open at 8am")]
        [TestCase(20, true, TestName = "Open at 8pm")]
        [TestCase(21, false, TestName = "Closed at 9pm")]
        public void BusinessOpenTimeIsCorrect_WhenDayIsNotSunday(int hour, bool isOpen)
        {
            fake.SetUtcNow(new DateTimeOffset(2024, 1, 1, hour, 0, 1, TimeSpan.Zero));  // Monday
            Assert.That(busOp.IsOpenHours(), Is.EqualTo(isOpen));
        }

        [Category("Sunday Hours")]
        [TestCase(9, false, TestName = "Closed at 9am")]
        [TestCase(10, true, TestName = "Open at 10am")]
        [TestCase(18, true, TestName = "Open at 6pm")]
        [TestCase(19, false, TestName = "Closed at 7pm")]
        public void BusinessOpenTimeIsCorrect_WhenDayIsSunday(int hour, bool isOpen)
        {
            fake.SetUtcNow(new DateTimeOffset(2023, 12, 31, hour, 0, 1, TimeSpan.Zero));  // Sunday
            Assert.That(busOp.IsOpenHours(), Is.EqualTo(isOpen));
        }
    }
}