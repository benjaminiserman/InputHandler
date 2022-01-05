namespace TestProject;
using System.Collections.Generic;
using InputHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Until_Tests
{
	[TestMethod]
	public void GetUntilWhiteSpace()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.GetUntilWhiteSpace(() =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Split('\n').Length - 1, 6);
	}

	[TestMethod]
	public void GetUntilEmpty()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.GetUntilEmpty(() =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Split('\n').Length - 1, 7);
	}

	[TestMethod]
	public void GetUntil()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.GetUntil(s => s == "saluton", () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Split('\n').Length - 1, 4);
	}

	[TestMethod]
	public void GetUntilIncludeFinal()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.GetUntil(s => s == "saluton", () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}, true).Split('\n').Length - 1, 5);
	}

	[TestMethod]
	public void ListUntilWhiteSpace()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntilWhiteSpace(() =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 6);
	}

	[TestMethod]
	public void ListUntilEmpty()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntilEmpty(() =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 7);
	}

	[TestMethod]
	public void ListUntil()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntil(s => s == "saluton", () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 4);
	}

	[TestMethod]
	public void ListUntilIncludeFinal()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntil(s => s == "saluton", () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}, true).Count, 5);
	}

	[TestMethod]
	public void ListTUntilWhiteSpace()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntilWhiteSpace(s => s.Length, () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 6);
	}

	[TestMethod]
	public void ListTUntilEmpty()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntilEmpty(s => s.Length, () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 7);
	}

	[TestMethod]
	public void ListTUntil()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntil(s => s == "saluton", s => s.Length, () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}).Count, 4);
	}

	[TestMethod]
	public void ListTUntilIncludeFinal()
	{
		List<string> input = new() { "hello", "hi", "hola", "bonjour", "saluton", "你好", "    ", "" };

		Assert.AreEqual(Input.ListUntil(s => s == "saluton", s => s.Length, () =>
		{
			string x = input[0];
			input.RemoveAt(0);
			return x;
		}, true).Count, 5);
	}
}