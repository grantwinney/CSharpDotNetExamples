# C# / .NET Examples

This repo goes with [my blog posts](https://grantwinney.com) that relate to specific [versions of C#](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history) and [versions of .NET](https://learn.microsoft.com/en-us/dotnet/core/whats-new/), which are [very closely related](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/relationships-between-language-and-library) and usually updated at the same time _(see [here](https://github.com/dotnet/csharplang/blob/main/Language-Version-History.md) and [here](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)#Versions))_. I sometimes upload code to separate repos (like for [WinForms](https://github.com/grantwinney/Surviving-WinForms) and [misc topics](https://github.com/grantwinney/BlogCodeSamples)), or to [Gist](https://gist.github.com/grantwinney) or [JsFiddle](https://jsfiddle.net/user/grantwinney/fiddles/) for shorter snippets.

The list below has links to each blog post and the relevant code, separated by version of language/framework. Links with a `†` next to them are in a separate repo, most likely [Surviving WinForms](https://github.com/grantwinney/Surviving-WinForms), which applies concepts specifically to the WinForms framework.

## C# 12 / .NET 8

- Time Abstraction
  - Part 1 - How to use TimeProvider and FakeTimeProvider ([blog post](https://grantwinney.com/how-to-use-timeprovider-and-faketimeprovider), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2012/TimeAbstraction))
  - Part 2 - How to use TimeProvider and FakeTimeProvider with timers ([blog post](https://grantwinney.com/how-to-use-timeprovider-and-faketimeprovider-to-test-timers), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2012/TimeAbstraction_Timers))

## C# 11 / .NET 7

- Generic Math Support series ([source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2011/GenericMathSupport))
  - Part 1 - What's a static abstract interface method? ([blog post](https://grantwinney.com/whats-a-static-abstract-interface-method-in-c))
  - Part 2 - How do I overload arithmetic, equality, and comparison operators? ([blog post](https://grantwinney.com/how-do-i-overload-operators-in-csharp))
  - Part 3 - What is Generic Math Support? ([blog post](https://grantwinney.com/whats-generic-math-support-in-csharp))
- Generic Attributes ([blog post](https://grantwinney.com/what-are-generic-attributes), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2011/GenericAttributes))
- List Patterns ([blog post](https://grantwinney.com/whats-a-list-pattern-in-csharp), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2011/ListPatternMatching))

## C# 10 / .NET 6

- _None_

## C# 9 / .NET 5

- Switch/Case Pattern Matching (vs if/else) ([blog post](https://grantwinney.com/if-else-vs-switch-case-pattern-matching), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2009/SwitchPatternMatchingVsIfElse))

## C# 8 / .NET Core 3.x

- _None_

## C# 7 / .NET 4.7

- Local Functions (aka nested methods) ([blog post](https://grantwinney.com/local-functions-in-csharp-aka-nested-methods), [source code](https://github.com/grantwinney/SurvivingWinForms/tree/master/ClarityConciseness/LocalFunctions)) †
- Tuples and Deconstruction ([blog post](https://grantwinney.com/using-tuple-and-deconstruction-to-return-multiple-values), [source code](https://github.com/grantwinney/SurvivingWinForms/tree/master/ClarityConciseness/TupleDeconstruction)) †
- Adding **deconstructors** to your own (and built-in) types in C# ([blog post](https://grantwinney.com/adding-deconstructors-in-csharp-is-it-worth-it), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2007/DeconstructingUserDefinedTypes))

## C# 6 / .NET 4.6

- Null-conditional and Null-coalescing operators ([blog post](https://grantwinney.com/null-conditional-and-null-coalescing-operators), [source code](https://github.com/grantwinney/SurvivingWinForms/tree/master/ClarityConciseness/NullHandlingOperators)) †
- Nameof ([blog post](https://grantwinney.com/using-nameof-to-avoid-magic-strings), [source code](https://github.com/grantwinney/Surviving-WinForms/tree/master/AntiPatterns/MagicStrings/NameOfVersusMagicStrings)) †
- String Interpolation ([blog post](https://grantwinney.com/using-string-interpolation-to-craft-readable-strings), [source code](https://github.com/grantwinney/SurvivingWinForms/tree/master/ClarityConciseness/StringInterpolation)) †

## C# 5 / .NET 4.5

- _None_

## C# 4 / .NET 4

- Named Arguments ([blog post](https://grantwinney.com/named-arguments-in-c-pass-what-you-want-and-forget-the-rest), [source code](https://github.com/grantwinney/SurvivingWinForms/tree/master/ClarityConciseness/NamedArguments)) †

## C# 3 / .NET 3

- _None_

## C# 2 / .NET 2

- _None_

## C# 1 / .NET 1

- Attributes ([blog post](https://grantwinney.com/what-are-attributes-and-why-do-we-need-them/), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/C%23%2001/Attributes))
- Exceptions (throw vs throw ex) ([blog post](https://grantwinney.com/does-rethrowing-an-exception-in-csharp-still-reset-the-stack-trace/))

## General Concepts

* Implicit vs Explicit Conversion ([blog post](https://grantwinney.com/csharp-implicit-vs-explicit-conversion/), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/GeneralConcepts/ImplicitExplicitOperators))
* Singleton vs Scoped vs Transient ([blog post](https://grantwinney.com/difference-between-singleton-scoped-transient), [source code](https://github.com/grantwinney/CSharpDotNetExamples/tree/master/GeneralConcepts/SingletonVsTransientDI))
