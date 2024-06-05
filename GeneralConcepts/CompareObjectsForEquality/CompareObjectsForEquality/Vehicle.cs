namespace CompareObjectsForEquality;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Vehicle)
            return false;

        var otherVehicle = (Vehicle)obj;

        if (Make != otherVehicle.Make || Model != otherVehicle.Model || Year != otherVehicle.Year)
            return false;

        return true;
    }

    public static bool operator ==(Vehicle x, Vehicle y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(Vehicle x, Vehicle y)
    {
        return !x.Equals(y);
    }

    public override int GetHashCode()
    {
        return (Make?.GetHashCode() ?? 0) ^ (Model?.GetHashCode() ?? 0) ^ Year.GetHashCode();
    }
}
