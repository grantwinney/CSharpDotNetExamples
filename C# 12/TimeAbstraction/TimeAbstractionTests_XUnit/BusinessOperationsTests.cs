using Microsoft.Extensions.Time.Testing;
using TimeAbstraction;

namespace TimeAbstractionTests_XUnit
{
    public class BusinessOperationsTests
    {
        private readonly FakeTimeProvider fake;
        private readonly BusinessOperations busOp;

        public BusinessOperationsTests()
        {
            fake = new();
            busOp = new(fake);
        }

        [Theory]
        [Trait("Category", "Monday Hours")]
        [InlineData(7, false)]   // 7a
        [InlineData(8, true)]    // 8a
        [InlineData(20, true)]   // 8p
        [InlineData(21, false)]  // 9p
        public void BusinessOpenTimeIsCorrect_WhenDayIsNotSunday(int hour, bool isOpen)
        {
            fake.SetUtcNow(new DateTimeOffset(2024, 1, 1, hour, 0, 1, TimeSpan.Zero));  // Monday
            Assert.Equal(isOpen, busOp.IsOpenHours());
        }

        [Theory]
        [Trait("Category", "Sunday Hours")]
        [InlineData(9, false)]   // 9a
        [InlineData(10, true)]   // 10a
        [InlineData(18, true)]   // 6p
        [InlineData(19, false)]  // 7p
        public void BusinessOpenTimeIsCorrect_WhenDayIsSunday(int hour, bool isOpen)
        {
            fake.SetUtcNow(new DateTimeOffset(2023, 12, 31, hour, 0, 1, TimeSpan.Zero));  // Sunday
            Assert.Equal(isOpen, busOp.IsOpenHours());
        }

        [Fact]
        [Trait("Category", "FakeTimeProvider Tests")]
        public void FakeTimeProvider_ThrowsAnException_WhenGoingBackInTime()
        {
            var laterDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var earlierDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            fake.SetUtcNow(laterDate);
            Assert.Throws<ArgumentOutOfRangeException>(() => fake.SetUtcNow(earlierDate));
        }

        [Fact]
        [Trait("Category", "FakeTimeProvider Tests")]
        public void FakeTimeProvider_ThrowsAnException_WhenGoingBeforeY2K()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                fake.SetUtcNow(new DateTimeOffset(1999, 1, 1, 0, 0, 0, TimeSpan.Zero)));
        }
    }
}
