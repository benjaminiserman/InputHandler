# InputHandler
A small library for handling user input in console apps

All methods are contained in a static class Input within the InputHandler namespace, and include XML documentation.

TestProject contains unit tests for every method.

How to decide which method to use:

Want the user to pick from a set of options?

Want the user to input yes/no? => GetYN
(includes overload to specify your own options for yes/no)

Want the user to input *specifically* y/n? => GetYNStrict

Want the user to choose from a collection of options? => GetOption
(includes generic overload if you want to convert it off of string after, and one if you want them to choose from string keys in a Dictionary)



Want the user to enter any input that passes a check or doesn't error?

Want to get the first input that doesn't error? => Get

Want to get the first input that passes a check? => GetCheck

Want to get the first input that passes a check without throwing an exception? => GetCheck<T>

Want to get an input and convert it into a bool? => GetBool



Want the user to enter a block of text?

Want the user to enter a block of text ending in the first line of whitespace? => GetUntilWhiteSpace

Want the user to enter a block of text ending in the first null or empty line? => GetUntilEmpty

Want the user to enter a block of text until they enter a line passing a specified check? => GetUntil



Want the user to enter a series of inputs?

Want the user to enter lines until they enter a line of whitespace? ListUntilWhiteSpace, YieldUntilWhiteSpace

Want the user to enter lines until they enter a null or empty line? ListUntilEmpty, YieldUntilEmpty

Want the user to enter lines until they enter a line passing a specified check? ListUntil, YieldUntil