namespace ImplicitExplicitOperators;

public class Person(string name)
{
    private readonly string _name = name;

    /// <summary>
    /// Implicitly convert a string to a new Person.
    /// </summary>
    /// <param name="name"></param>
    public static implicit operator Person(string name)
    {
        return new Person(name);
    }

    /// <summary>
    /// Implicitly convert a Person to a string
    /// </summary>
    /// <remarks>
    /// Depending on what other fields are defined in Person,
    /// this implicit conversion may lose a lot of data.
    /// </remarks>
    /// <param name="person"></param>
    public static implicit operator string(Person person)
    {
        return person._name;
    }
}
