using System;

namespace ImplicitExplicitOperators;

public class Birthday(DateTime birthday)
{
    private readonly DateTime _birthday = birthday;

    /// <summary>
    /// Implicitly convert a DateTime to a new Birthday.
    /// </summary>
    /// <param name="birthday"></param>
    public static implicit operator Birthday(DateTime birthday)
    {
        return new Birthday(birthday);
    }

    /// <summary>
    /// Implicitly convert a Birthday to a DateTime.
    /// </summary>
    /// <remarks>
    /// Depending on what other fields are defined in Birthday,
    /// this implicit conversion may lose a lot of data.
    /// </remarks>
    /// <param name="birthday"></param>
    //public static implicit operator DateTime(Birthday birthday)
    //{
    //    return birthday._birthday;
    //}

    public static explicit operator DateTime(Birthday birthday)
    {
        return birthday._birthday;
    }
}
