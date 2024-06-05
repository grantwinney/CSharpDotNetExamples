namespace EqualityTests;

public class DefaultEqualityTests
{
    [Fact]
    public void GivenDefaultEqualityComparison_WhenComparingASingleInstance_ThenPeopleAreEqual()
    {
        var person1 = new Person { Name = "Jay", Age = 25 };
        var person2 = person1;

        Assert.True(person1.Equals(person2));
        Assert.True(person1 == person2);
    }

    [Fact]
    public void GivenDefaultEqualityComparison_WhenComparingTwoInstances_ThenPeopleAreNotEqual()
    {
        var person1 = new Person { Name = "Jay", Age = 25 };
        var person2 = new Person { Name = "Jay", Age = 25 };

        Assert.False(person1.Equals(person2));
        Assert.False(person1 == person2);
    }
}