namespace InputHandler;
using System;

public static partial class Input
{
    /// <summary>
    /// Prompts for input until <paramref name="action"/> does not throw an exception. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="action">The action called with the input from <paramref name="getString"/>.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The function that creates the message sent if <paramref name="action"/> throws an exception. The first parameter receives the string that errored. The second parameter receives the Exception caught. (optional)</param>
    public static void Get(Action<string> action, Func<string> getString = null, Action<string> write = null, Func<string, Exception, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        while (true)
        {
            string s = getString();

            try
            {
                action(s);
                return;
            }
            catch (Exception e)
            {
                write(getMessage?.Invoke(s, e) ?? $"{e.Message}... Please try again.");
            }
        }
    }

    /// <summary>
    /// Prompts for input until <paramref name="convert"/> does not throw an exception. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="convert">The function that converts the input from <paramref name="getString"/> into type <typeparamref name="T"/>.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The function that creates the message sent if <paramref name="convert"/> throws an exception. The first parameter receives the string that errored. The second parameter receives the Exception caught. (optional)</param>
    public static T Get<T>(Func<string, T> convert, Func<string> getString = null, Action<string> write = null, Func<string, Exception, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        while (true)
        {
            string s = getString();

            try
            {
                return convert(s);
            }
            catch (Exception e)
            {
                write(getMessage?.Invoke(s, e) ?? $"{e.Message}... Please try again.");
            }
        }
    }

    /// <summary>
    /// Prompts for input until <paramref name="check"/> returns true. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="check">The predicate used to check input from <paramref name="getString"/>.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The message sent if <paramref name="check"/> returns <see langword="false"/>. (optional)</param>
    /// <returns>The first input for which <paramref name="check"/> returns <see langword="true"/>.</returns>
    public static string GetCheck(Predicate<string> check, Func<string> getString = null, Action<string> write = null, Func<string, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        string s;
        while (!check(s = getString()))
        {
            write(getMessage?.Invoke(s) ?? "Invalid format... Please try again.");
        }

        return s;
    }

    /// <summary>
    /// Prompts for input and converts it using <paramref name="convert"/> until <paramref name="convert"/> does not throw an exception and <paramref name="check"/> returns true. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="convert">The function that converts the input from <paramref name="getString"/> into type <typeparamref name="T"/>.</param>
    /// <param name="check">The predicate used to check input from <paramref name="getString"/>.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The message sent if <paramref name="check"/> returns <see langword="false"/>. (optional)</param>
    /// <returns>The first input for which <paramref name="check"/> returns <see langword="true"/>.</returns>
    public static T GetCheck<T>(Func<string, T> convert, Predicate<T> check, Func<string> getString = null, Action<string> write = null, Func<string, Exception, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        T x;
        while (true)
        {
            string s = getString();

            try
            {
                x = convert(s);
            }
            catch (Exception e)
            {
                write(getMessage?.Invoke(s, e) ?? "Invalid format... Please try again.");
                continue;
            }

            if (check(x)) break;
            else write($"Input {s} (= {x}) does not pass check {check}");
        }

        return x;
    }

    /// <summary>
    /// Prompts for input and converts it using <paramref name="convert"/> until <paramref name="check"/> returns true and <paramref name="convert"/> does not throw an exception. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="convert">The function that converts the input from <paramref name="getString"/> into type <typeparamref name="T"/>.</param>
    /// <param name="check">The predicate used to check input from <paramref name="getString"/>.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The message sent if <paramref name="check"/> returns <see langword="false"/>. (optional)</param>
    /// <returns>The first input for which <paramref name="check"/> returns <see langword="true"/>.</returns>
    public static T GetCheck<T>(Func<string, T> convert, Predicate<string> check, Func<string> getString = null, Action<string> write = null, Func<string, Exception, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        T x;
        while (true)
        {
            string s = getString();
            if (check(s))
            {
                try
                {
                    x = convert(s);
                    break;
                }
                catch (Exception e)
                {
                    write(getMessage?.Invoke(s, e) ?? "Invalid format... Please try again.");
                    continue;
                }
            }
            else write($"Input {s} does not pass check {check}");
        }

        return x;
    }

    /// <summary>
    /// Prompts for input using  until <paramref name="convert"/> does not throw an exception. Can optionally use parameter <paramref name="getMessage"/> to specify an error message.
    /// </summary>
    /// <param name="convert">The predicate used to convert input from <paramref name="getString"/> into a bool.</param>
    /// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
    /// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
    /// <param name="getMessage">The function that creates the message sent if <paramref name="convert"/> throws an exception. The first parameter receives the string that errored. The second parameter receives the Exception caught. (optional)</param>
    /// <returns>The first result of <paramref name="convert"/> that does not throw an exception.</returns>
    public static bool GetBool(Predicate<string> convert, Func<string> getString = null, Action<string> write = null, Func<string, Exception, string> getMessage = null)
    {
        getString ??= Console.ReadLine;
        write ??= Console.WriteLine;

        while (true)
        {
            string s = getString();

            try
            {
                return convert(s);
            }
            catch (Exception e)
            {
                write(getMessage?.Invoke(s, e) ?? $"{e.Message}... Please try again.");
            }
        }
    }
}