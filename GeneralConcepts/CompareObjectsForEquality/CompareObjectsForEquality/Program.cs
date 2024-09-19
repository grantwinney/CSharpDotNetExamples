// .NET Framework and Equality

using CompareObjectsForEquality;

var name = "Mike";
if (name == "")
    Console.WriteLine("Hi there, stranger.");
else
    Console.WriteLine($"Hi, {name}!");

var age = 17;
var isAdult = age >= 18;
Console.WriteLine($"{name} {(isAdult ? "is" : "is not")} an adult.");

var today = new DateTime(2024, 1, 1);
Console.WriteLine(today == new DateTime(2024, 1, 1));


// ========== Custom Equality Comparison ==========

// Compare Person objects

var person = new Person { Name = "Jay", Age = 25 };
var samePerson = person;
var newPerson = new Person { Name = "Jay", Age = 25 };

Console.WriteLine(person.Equals(samePerson));  // true, same instance
Console.WriteLine(person == samePerson);       // true, same instance

Console.WriteLine(person.Equals(newPerson));   // false, different instances
Console.WriteLine(person == newPerson);        // false, different instances


// Compare Vehicle objects

var camry = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
var alsoCamry = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2024 };
var bugatti = new Vehicle { Make = "Bugatti", Model = "Chiron", Year = 2023 };

Console.WriteLine(camry.Equals(alsoCamry));  // true, custom equality logic
Console.WriteLine(camry == alsoCamry);       // true, custom equality logic

Console.WriteLine(camry.Equals(bugatti));    // false, custom equality logic
Console.WriteLine(camry == bugatti);         // false, custom equality logic
