
// Original Code
{
    var name = "Grant";
    var message = string.Format("Hello {0}, the date is {1:MM/dd/yyyy}.", name, DateTime.Now);
    
    Console.WriteLine(message);  // Hello Grant, the date is 04/04/2019.
}

// Replacing string.Format
{
    var name = "Grant";
    var message = $"Hello {name}, the date is {DateTime.Now:MM/dd/yyyy}.";
    
    Console.WriteLine(message);  // Hello Grant, the date is 04/04/2019.
}

// Attempt to move format string to const
{
    const string DATE_FORMAT = "MM/dd/yyyy";  // ignored

    var name = "Grant";
    var message = $"Hello {name}, the date is {DateTime.Now:DATE_FORMAT}.";

    Console.WriteLine(message);  // Hello Grant, the date is DATE_9OR4AT.
}

// Use ToString() override instead
{
    const string DATE_FORMAT = "MM/dd/yyyy";

    var name = "Grant";
    var message = $"Hello {name}, the date is {DateTime.Now.ToString(DATE_FORMAT)}.";
    Console.WriteLine(message);  // Hello Grant, the date is 04/04/2019.
}