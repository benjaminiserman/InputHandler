# InputHandler
A small library for handling user input in console apps

All methods are contained in a static class Input within the InputHandler namespace, and include XML documentation.

The UnitTests project contains unit tests for every method.
<br><br><br><br><br>
How to decide which method to use:

**Want the user to pick from a set of options?**

>Want the user to input yes/no? => GetYN
>(includes overload to specify your own options for yes/no)

>Want the user to input *specifically* y/n? => GetYNStrict

>Want the user to choose from a collection of options? => GetOption
>(includes generic overload if you want to convert it off of string after, and one if you want them to choose from string keys in a Dictionary)



**Want the user to enter one input...**

>that doesn't error? => Get

>that passes a check? => GetCheck

>that passes a check without throwing an exception? => GetCheck<T>

>and convert it into a bool? => GetBool



**Want the user to enter a block of text ending in...**

>the first line of whitespace? => GetUntilWhiteSpace

>the first null or empty line? => GetUntilEmpty

>the first line that passes a specified check? => GetUntil



**Want the user to enter a series of inputs ending in...**

>a line of whitespace? ListUntilWhiteSpace, YieldUntilWhiteSpace

>a null or empty line? ListUntilEmpty, YieldUntilEmpty

>a line that passes a specified check? ListUntil, YieldUntil
