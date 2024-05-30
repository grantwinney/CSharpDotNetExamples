using System;
using ImplicitExplicitOperators;


// Decimal / Int32

int quantity = 5;
decimal amount = quantity;

decimal amount2 = 50;
//int quantity2 = amount2;       // Implicit conversion won't work
int quantity2 = (int)amount2;    //   but an explicit conversion will


// Person
Person bob = new Person("Bob");  // Pass the name into the constructor
Person mary = "Mary";            //   or just use the implicit conversion
string name = mary;              // There's a potential loss of data here = bad
        

// Birthday           
Birthday birthday = new DateTime(1970, 6, 2);  // implicit conversion of DateTime to Birthday
DateTime birthdate = (DateTime)birthday;       // explicit conversion of Birthday to DateTime
