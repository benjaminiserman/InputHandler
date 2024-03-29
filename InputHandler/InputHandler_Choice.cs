﻿namespace InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Input
{
	/// <summary>
	/// Prompts for input until it receives y, n, yes, or no (not case sensitive). Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if something other than y, n, yes, or no is inputted. (optional)</param>
	/// <returns>Once a valid input is entered: <see langword="true"/> if input was "y" or "yes", <see langword="false"/> if input was "n" or "no".</returns>
	public static bool GetYN(Func<string> getString = null, Action<string> write = null, string message = "Invalid format... use y or n.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		while (true)
		{
			switch (getString().Trim().ToLower())
			{
				case "y":
				case "yes":
					return true;
				case "n":
				case "no":
					return false;
				default:
					write(message);
					continue;
			}
		}
	}

	/// <summary>
	/// Prompts for input using until it receives a string contained in <paramref name="yesOptions"/> or <paramref name="noOptions"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="yesOptions">A collection of strings for which the method should return true.</param>
	/// <param name="noOptions">A collection of strings for which the method should return false.</param>
	/// <param name="comparison">The string comparison to be used. Defaults to OrdinalIgnoreCase. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string contained in neither <paramref name="yesOptions"/> nor <paramref name="noOptions"/> is inputted. (optional)</param>
	/// <returns>Once a valid input is entered: <see langword="true"/> if <paramref name="yesOptions"/> contains input, <see langword="false"/> if <paramref name="noOptions"/> contains input. In the case that both <paramref name="yesOptions"/> and <paramref name="noOptions"/> contain input, returns <see langword="true"/>.</returns>
	public static bool GetYN(IEnumerable<string> yesOptions, IEnumerable<string> noOptions, StringComparison comparison = StringComparison.OrdinalIgnoreCase, Func<string> getString = null, Action<string> write = null, string message = "Specified input is not a valid yes or no option. Please try a different input.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		StringComparer comparer = StringComparer.FromComparison(comparison);

		while (true)
		{
			string s = getString();
			if (yesOptions.Contains(s, comparer)) return true;
			else if (noOptions.Contains(s, comparer)) return false;
			else write(message);
		}
	}

	/// <summary>
	/// Prompts for input using until it receives y or n (not case sensitive). Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if something other than y or n is inputted. (optional)</param>
	/// <returns>Once a valid input is entered: <see langword="true"/> if input was "y", <see langword="false"/> if input was "n".</returns>
	public static bool GetYNStrict(Func<string> getString = null, Action<string> write = null, string message = "Invalid format... use y or n.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		while (true)
		{
			switch (getString().Trim().ToLower())
			{
				case "y":
					return true;
				case "n":
					return false;
				default:
					write(message);
					continue;
			}
		}
	}

	/// <summary>
	/// Prompts for input until it receives a string contained in <paramref name="options"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="options">The collection of valid options.</param>
	/// <param name="comparison">The string comparison to be used. Defaults to Ordinal. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string not contained in <paramref name="options"/> is inputted. (optional)</param>
	/// <returns>The first string entered contained within <paramref name="options"/></returns>
	public static string GetOption(IEnumerable<string> options, StringComparison comparison = StringComparison.Ordinal, Func<string> getString = null, Action<string> write = null, string message = "Value inputted is not a valid option.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		StringComparer comparer = StringComparer.FromComparison(comparison);

		while (true)
		{
			string s = getString();
			if (options.Contains(s, comparer))
			{
				return options.First(x => comparer.Compare(s, x) == 0);
			}
			else write(message);
		}
	}

	/// <summary>
	/// Prompts for input until it receives a string contained in <paramref name="options"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="options">The collection of valid options.</param>
	/// <param name="convert">The predicate used to convert input from <paramref name="getString"/> into a bool.</param>
	/// <param name="comparison">The string comparison to be used. Defaults to Ordinal. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string not contained in <paramref name="options"/> is inputted. (optional)</param>
	/// <returns>The first string entered contained within <paramref name="options"/></returns>
	public static T GetOption<T>(IEnumerable<string> options, Func<string, T> convert, StringComparison comparison = StringComparison.Ordinal, Func<string> getString = null, Action<string> write = null, string message = "Value inputted is not a valid option.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		StringComparer comparer = StringComparer.FromComparison(comparison);

		while (true)
		{
			string s = getString();
			if (options.Contains(s, comparer))
			{
				return convert(options.First(x => comparer.Compare(s, x) == 0));
			}
			else write(message);
		}
	}

	/// <summary>
	/// Prompts for input until it receives a string contained as a key within <paramref name="options"/>, then returns the corresponding value within <paramref name="options"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="options">The dictionary of valid options.</param>
	/// <param name="comparison">The string comparison to be used. Defaults to Ordinal. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string not contained in <paramref name="options"/> is inputted. (optional)</param>
	/// <returns>The value of the first string entered that can be used as a key in <paramref name="options"/></returns>
	public static T GetOption<T>(Dictionary<string, T> options, StringComparison comparison = StringComparison.Ordinal, Func<string> getString = null, Action<string> write = null, string message = "Value inputted is not a valid option.")
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		StringComparer comparer = StringComparer.FromComparison(comparison);

		while (true)
		{
			string s = getString();
			if (options.Keys.Contains(s, comparer))
			{
				return options[options.Keys.First(x => comparer.Compare(s, x) == 0)];
			}
			else write(message);
		}
	}

	/// <summary>
	/// Prompts for input until it receives a string contained as a possible option within a ICollection<string> key in <paramref name="options"/>, then returns the corresponding value within <paramref name="options"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="options">The dictionary of valid options.</param>
	/// <param name="comparison">The string comparison to be used. Defaults to Ordinal. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string not contained in <paramref name="options"/> is inputted. (optional)</param>
	/// <returns>The value of the first string entered that can be used as a key in <paramref name="options"/></returns>
	public static T GetOption<T, T2>(Dictionary<T2, T> options, StringComparison comparison = StringComparison.Ordinal, Func<string> getString = null, Action<string> write = null, string message = "Value inputted is not a valid option.")
		where T2 : ICollection<string>
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		StringComparer comparer = StringComparer.FromComparison(comparison);

		while (true)
		{
			string s = getString();
			if (options.Keys.Any(x => x.Contains(s, comparer)))
			{
				return options[options.Keys.First(x => x.Contains(s, comparer))];
			}
			else write(message);
		}
	}

	/// <summary>
	/// Prompts for input until it receives a valid name from enum <typeparamref name="T"/>, then returns the corresponding value from <typeparamref name="T"/>. Can optionally use parameter <paramref name="message"/> to specify an error message.
	/// </summary>
	/// <param name="ignoreCase">Whether or not to ignore case. Defaults to true. (optional)</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="write">The function used to output errors. Defaults to Console.WriteLine. (optional)</param>
	/// <param name="message">The error message sent if a string not contained in <typeparamref name="T"/> is inputted. (optional)</param>
	/// <returns>The first valid <typeparamref name="T"/> entered.</returns>
	public static T GetOption<T>(bool ignoreCase = true, Func<string> getString = null, Action<string> write = null, string message = "Value inputted is not a valid option.")
		where T : Enum
	{
		getString ??= Console.ReadLine;
		write ??= Console.WriteLine;

		while (true)
		{
			string s = getString();
			if (Enum.TryParse(typeof(T), s, ignoreCase, out var result))
			{
				return (T)result;
			}
			else write(message);
		}
	}
}