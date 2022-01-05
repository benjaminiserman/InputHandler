# InputHandler
A small library for handling user input in console apps

All methods are contained in a static class Input within the InputHandler namespace.

Methods Available:

```cs
// Prompts for input using getString until action does not throw an exception. Can optionally use parameter getMessage to specify an error message.
void Get(Func<string> getString, Action<string> action, Func<string, Exception, string> getMessage = null) {}

// Prompts for input using getString until check returns true. Can optionally use parameter getMessage to specify an error message.
string Get(Func<string> getString, Predicate<string> check, Func<string, string> getMessage = null) {}

// Prompts for input using getString until it receives y, n, yes, or no. Can optionally use parameter message to specify an error message.
bool GetYN(Func<string> getString, string message = "Invalid format... use y or n.") {}

// Prompts for input using getString until it receives a string contained in yesOptions or noOptions. Can optionally use parameter message to specify an error message.
bool GetYN(Func<string> getString, IEnumerable<string> yesOptions, IEnumerable<string> noOptions, string message = "Specified input is not a valid yes or no option. Please try a different input.") {}

// Prompts for input using getString until it receives y or n. Can optionally use parameter message to specify an error message.
bool GetYNStrict(Func<string> getString, string message = "Invalid format... use y or n.") {}

// Prompts for input using getString until convert does not throw an exception. Can optionally use parameter message to specify an error message.
bool GetBool(Func<string> getString, Predicate<string> convert, Func<string, Exception, string> getMessage = null) {}

// Takes input using getString until a null, empty, or whitespace string is sent.
string GetUntilEmpty(Func<string> getString) {}

// Takes input using getString until shouldStop returns true.
string GetUntil(Func<string> getString, Predicate<string> shouldStop) {}

// Takes input using getString until a null, empty, or whitespace string is sent.
List<string> ListUntilEmpty(Func<string> getString) {}
List<T> ListUntilEmpty<T>(Func<string> getString, Func<string, T> convert) {}

// Takes input using getString until shouldStop returns true.
List<string> ListUntil(Func<string> getString, Predicate<string> shouldStop, bool includeFinal = false) {}
List<T> ListUntil<T>(Func<string> getString, Predicate<string> shouldStop, Func<string, T> convert, bool includeFinal = false) {}

// Yield-returns consecutive inputs grabbed by getString until a null, empty, or whitespace string is sent.
IEnumerable<string> YieldUntilEmpty(Func<string> getString) {}

// Yield-returns consecutive inputs grabbed by getString until shouldStop returns true.
IEnumerable<string> YieldUntil(Func<string> getString, Predicate<string> shouldStop, bool includeFinal = false) {}

// Prompts for input using getString until it receives a string contained in options. Can optionally use parameter message to specify an error message.
string GetOption(Func<string> getString, IEnumerable<string> options, string message = "Value inputted is not a valid option.") {}
```


Example Program:
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using InputHandler;

public class Program
{
    // sample project, gets numbers and either adds or multiples them depending on user input
    public static void Main()
    {
        string[] addOptions = new string[] { "add", "addition", "+", "plus", "sum", "a" };
        string[] multOptions = new string[] { "multiply", "multiplication", "*", "x", "mult", "product", "m" };

        Console.WriteLine("Would you like to add or multiply?");

        string optionChosen = Input.Get(Console.ReadLine, s => addOptions.Contains(s) || multOptions.Contains(s));
        bool isAddition = addOptions.Contains(optionChosen);

        List<double> values = new();
        
        while (true)
        {
            Console.WriteLine("Take another value? (y/n)");
            if (Input.GetYN(Console.ReadLine))
            {
                Console.WriteLine("Enter value:");
                Input.Get(Console.ReadLine, s => values.Add(double.Parse(s)), (_, _) => "Must enter a value that can be parsed to double.");
            }
            else break;
        }

        if (values.Count == 0)
        {
            Console.WriteLine("Must have values to complete operation!");
            return;
        }

        if (isAddition)
        {
            double sum = 0;
            foreach (var x in values) sum += x;
            Console.WriteLine($"Sum is: {sum}");
        }
        else
        {
            double product = 1;
            foreach (var x in values) product *= x;
            Console.WriteLine($"Product is: {product}");
        }

        /* Note: if you'd like to take trimmed lowercase input for the operation, for example, you could do something like this:
         * 
         * string optionChosen = Input.Get(() => Console.ReadLine().Trim().ToLower(), s => addOptions.Contains(s) || multOptions.Contains(s));
         *
         */
    }
}
```
