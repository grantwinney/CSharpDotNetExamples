namespace EqualityTests;

public class CustomEqualityTests
{
    [Fact]
    public void GivenCustomEqualityComparison_WhenPropertiesMatch_ThenVehiclesAreEqual()
    {
        var vehicle1 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
        var vehicle2 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };

        Assert.True(vehicle1.Equals(vehicle2));
        Assert.True(vehicle1 == vehicle2);
    }

    [Fact]
    public void GivenCustomEqualityComparison_WhenPropertiesDoNotMatch_ThenVehiclesAreNotEqual()
    {
        var vehicle1 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
        var vehicle2 = new Vehicle { Make = "Bugatti", Model = "Chiron", Year = 2023 };

        Assert.False(vehicle1.Equals(vehicle2));
        Assert.False(vehicle1 == vehicle2);
    }

    [Fact]
    public void GivenCustomEqualityComparison_WhenPropertiesMatch_ThenHashCodesAreEqual()
    {
        var vehicle1 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
        var vehicle2 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };

        Assert.True(vehicle1.GetHashCode() == vehicle2.GetHashCode());
    }

    [Fact]
    public void GivenCustomEqualityComparison_WhenPropertiesDoNotMatch_ThenHashCodesAreNotEqual()
    {
        var vehicle1 = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
        var vehicle2 = new Vehicle { Make = "Bugatti", Model = "Chiron", Year = 2023 };

        Assert.False(vehicle1.GetHashCode() == vehicle2.GetHashCode());
    }

    [Fact]
    public void GivenCustomEqualityComparison_WhenPropertiesAreMissing_ThenNoExceptionThrown()
    {
        var vehicle1 = new Vehicle();
        var vehicle2 = new Vehicle();

        Assert.Null(Record.Exception(() => vehicle1.GetHashCode()));
        Assert.Null(Record.Exception(() => vehicle2.GetHashCode()));
    }
}
