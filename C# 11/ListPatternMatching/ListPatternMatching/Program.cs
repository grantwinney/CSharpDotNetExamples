using ListPatternMatching;


// EXAMPLE 1 - Match on inconsistent CSV formats
StoreProcessor.RunTotals();
Console.WriteLine();


// EXAMPLE 2 - Match a list of values in an XML node
SchoolEngine.PrintGrades();
Console.WriteLine();


// EXAMPLE 3 - Match the first few lines of a text file
TextFileParser.ExtractFileHeaders();
Console.WriteLine();


// EXAMPLE 4 - Match a variety of combinations of arguments being passed to a console app
if (args is ["s", var fileToSearch, var searchTerm])
{
    // Search for specified file
    Console.WriteLine($"Searching for '{searchTerm}' in {fileToSearch}...");
}
else if (args is ["d", var fileToDelete])
{
    // Delete specified file
    Console.WriteLine($"Deleting {fileToDelete}...");
}
else if (args is ["c", var fileToCreate])
{
    // Create specified file
    Console.WriteLine($"Creating {fileToCreate}...");
}
else if (args is [..])
{
    Console.WriteLine("Invalid input for args!");
}
