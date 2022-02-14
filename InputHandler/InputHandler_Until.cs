namespace InputHandler;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Contains a number of methods for handling user input.
/// </summary>
public static partial class Input
{
	/// <summary>
	/// Takes input until a <see langword="null"/>, empty, or whitespace string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A string representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static string GetUntilWhiteSpace(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		StringBuilder stringBuilder = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrWhiteSpace(input)) return stringBuilder.ToString();
			else stringBuilder.AppendLine(input);
		}
	}

	/// <summary>
	/// Takes input until a <see langword="null"/> or empty string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A string representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static string GetUntilEmpty(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		StringBuilder stringBuilder = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrEmpty(input)) return stringBuilder.ToString();
			else stringBuilder.AppendLine(input);
		}
	}

	/// <summary>
	/// Takes input until <paramref name="shouldStop"/> returns <see langword="true"/>.
	/// </summary>
	/// <param name="shouldStop">The predicate that checks input to determine whether or not to stop taking input. If this returns true, the method will stop taking input.</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="includeFinal">Whether or not to include the final (breaking) input. (optional)</param>
	/// <returns>A string representing all input received, including the final (breaking) input if <param name="includeFinal"> is <see langword="null">.</returns>
	public static string GetUntil(Predicate<string> shouldStop, Func<string> getString = null, bool includeFinal = false)
	{
		getString ??= Console.ReadLine;

		StringBuilder stringBuilder = new();
		while (true)
		{
			string input = getString();
			if (shouldStop(input))
			{
				if (includeFinal) stringBuilder.AppendLine(input);
				return stringBuilder.ToString();
			}
			else stringBuilder.AppendLine(input);
		}
	}

	/// <summary>
	/// Takes input until a <see langword="null"/>, empty, or whitespace string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A list of strings representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static List<string> ListUntilWhiteSpace(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		List<string> list = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrWhiteSpace(input)) return list;
			else list.Add(input);
		}
	}

	/// <summary>
	/// Takes input until a <see langword="null"/>, empty, or whitespace string is sent.
	/// </summary>
	/// <param name="convert">The function that converts user input into type <typeparamref name="T"/></param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A list of <typeparamref name="T"/> representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static List<T> ListUntilWhiteSpace<T>(Func<string, T> convert, Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		List<T> list = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrWhiteSpace(input)) return list;
			else list.Add(convert(input));
		}
	}

	/// <summary>
	/// Takes input until a <see langword="null"/> or empty string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A list of strings representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static List<string> ListUntilEmpty(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		List<string> list = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrEmpty(input)) return list;
			else list.Add(input);
		}
	}

	/// <summary>
	/// Takes input until a <see langword="null"/> or empty string is sent.
	/// </summary>
	/// <param name="convert">The function that converts user input into type <typeparamref name="T"/></param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>A list of <typeparamref name="T"/> representing all input received excluding the final <see langword="null"/>, empty, or whitespace string.</returns>
	public static List<T> ListUntilEmpty<T>(Func<string, T> convert, Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		List<T> list = new();
		while (true)
		{
			string input = getString();
			if (string.IsNullOrEmpty(input)) return list;
			else list.Add(convert(input));
		}
	}

	/// <summary>
	/// Takes input until <paramref name="shouldStop"/> returns <see langword="true"/>.
	/// </summary>
	/// <param name="shouldStop">The predicate that checks input to determine whether or not to stop taking input. If this returns true, the method will stop taking input.</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="includeFinal">Whether or not to include the final (breaking) input. (optional)</param>
	/// <returns>A list of strings representing all input received including the final (breaking) input if <paramref name="includeFinal"/> is <see langword="true"/>.</returns>
	public static List<string> ListUntil(Predicate<string> shouldStop, Func<string> getString = null, bool includeFinal = false)
	{
		getString ??= Console.ReadLine;

		List<string> list = new();
		while (true)
		{
			string input = getString();
			if (shouldStop(input))
			{
				if (includeFinal) list.Add(input);
				return list;
			}
			else list.Add(input);
		}
	}

	/// <summary>
	/// Takes input until <paramref name="shouldStop"/> returns <see langword="true"/>.
	/// </summary>
	/// <param name="shouldStop">The predicate that checks input to determine whether or not to stop taking input. If this returns true, the method will stop taking input.</param>
	/// <param name="convert">The function that converts user input into type <typeparamref name="T"/></param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="includeFinal">Whether or not to include the final (breaking) input. (optional)</param>
	/// <returns>A list of <typeparamref name="T"/> representing all input received including the final (breaking) input if <paramref name="includeFinal"/> is <see langword="true"/>.</returns>
	public static List<T> ListUntil<T>(Predicate<string> shouldStop, Func<string, T> convert, Func<string> getString = null, bool includeFinal = false)
	{
		getString ??= Console.ReadLine;

		List<T> list = new();
		while (true)
		{
			string input = getString();
			if (shouldStop(input))
			{
				if (includeFinal) list.Add(convert(input));
				return list;
			}
			else list.Add(convert(input));
		}
	}

	/// <summary>
	/// Yield-returns consecutive inputs until a <see langword="null"/>, empty, or whitespace string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>Each consecutive input entered excluding the final (breaking) input.</returns>
	public static IEnumerable<string> YieldUntilWhiteSpace(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		while (true)
		{
			string input = getString();
			if (string.IsNullOrWhiteSpace(input)) break;
			yield return input;
		}
	}

	/// <summary>
	/// Yield-returns consecutive inputs until a <see langword="null"/> or empty string is sent.
	/// </summary>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <returns>Each consecutive input entered excluding the final (breaking) input.</returns>
	public static IEnumerable<string> YieldUntilEmpty(Func<string> getString = null)
	{
		getString ??= Console.ReadLine;

		while (true)
		{
			string input = getString();
			if (string.IsNullOrEmpty(input)) break;
			yield return input;
		}
	}

	/// <summary>
	/// Yield-returns consecutive inputs until <paramref name="shouldStop"/> returns <see langword="true"/>.
	/// </summary>
	/// <param name="shouldStop">The predicate that checks input to determine whether or not to stop taking input. If this returns true, the method will stop taking input.</param>
	/// <param name="getString">The function used to get user input. Defaults to Console.ReadLine. (optional)</param>
	/// <param name="includeFinal">Whether or not to include the final (breaking) input. (optional)</param>
	/// <returns>Each consecutive input entered, including the final (breaking) input if <paramref name="shouldStop"/> is <see langword="true"/></returns>
	public static IEnumerable<string> YieldUntil(Predicate<string> shouldStop, Func<string> getString = null, bool includeFinal = false)
	{
		getString ??= Console.ReadLine;

		while (true)
		{
			string input = getString();
			if (shouldStop(input))
			{
				if (includeFinal) yield return input;
				break;
			}

			yield return input;
		}
	}
}