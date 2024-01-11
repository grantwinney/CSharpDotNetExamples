using Microsoft.Extensions.Time.Testing;
using Moq;
using TimeAbstractionTimers;
using TimeAbstractionTimers.Wrappers;

namespace TimeAbstractionTimers_Tests
{
    public class TimerSamplesTests
    {
        private TimerSamples timerSamples;
        private FakeTimeProvider fakeTimeProvider;
        private Mock<IConsole> consoleMock;
        private Mock<IFile> fileMock;

        [SetUp]
        public void Setup()
        {
            fakeTimeProvider = new FakeTimeProvider();
            consoleMock = new Mock<IConsole>();
            fileMock = new Mock<IFile>();
            timerSamples = new TimerSamples(fakeTimeProvider, consoleMock.Object, fileMock.Object);
        }

        [Test]
        public void PrintTimeTimer_NoTGIFMessage_WhenNotFriday()
        {
            fakeTimeProvider.SetUtcNow(new DateTimeOffset(2024, 1, 9, 1, 0, 0, TimeSpan.Zero)); // Tues
            fakeTimeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);

            // Start the timer, then teleport 5 seconds into the future
            timerSamples.StartTimers();
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(5));

            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("THE CURRENT TIME"))), Times.AtLeastOnce());
            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("TGIF!!!"))), Times.Never());
        }

        [Test]
        public void PrintTimeTimer_NoTGIFMessage_WhenFridayButNotEvening()
        {
            fakeTimeProvider.SetUtcNow(new DateTimeOffset(2024, 1, 12, 1, 0, 0, TimeSpan.Zero)); // Fri @ 1am
            fakeTimeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);

            // Start the timer, then teleport 5 seconds into the future
            timerSamples.StartTimers();
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(5));

            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("THE CURRENT TIME"))), Times.AtLeastOnce());
            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("TGIF!!!"))), Times.Never());
        }

        [Test]
        public void PrintTimeTimer_TGIFMessage_WhenFridayEvening()
        {
            fakeTimeProvider.SetUtcNow(new DateTimeOffset(2024, 1, 12, 17, 0, 0, TimeSpan.Zero)); // Fri @ 5pm
            fakeTimeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);

            // Start the timer, then teleport 5 seconds into the future
            timerSamples.StartTimers();
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(5));

            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("THE CURRENT TIME"))), Times.Never());
            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("TGIF!!!"))), Times.AtLeastOnce());
        }

        [Test]
        public void PrintTimeTimer_MessageTransitionsCorrectly_WhenFridayAfternoonTurnsToEvening()
        {
            fakeTimeProvider.SetUtcNow(new DateTimeOffset(2024, 1, 12, 16, 59, 57, TimeSpan.Zero)); // Fri @ 4:59:57pm
            fakeTimeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);

            // Start the timer, then teleport 5 seconds into the future
            timerSamples.StartTimers();
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(5));

            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("THE CURRENT TIME"))), Times.AtLeastOnce());
            consoleMock.Verify(x => x.WriteLine(It.Is<string>(x => x.StartsWith("TGIF!!!"))), Times.AtLeastOnce());
        }
    }
}