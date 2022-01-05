namespace TestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using InputHandler;

[TestClass]
public class Choice_Tests
{
	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetYN(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("y");

		Assert.AreEqual(Input.GetYN(getString: () => queue.Dequeue()), true);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("yes");

		Assert.AreEqual(Input.GetYN(getString: () => queue.Dequeue()), true);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("n");

		Assert.AreEqual(Input.GetYN(getString: () => queue.Dequeue()), false);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("no");

		Assert.AreEqual(Input.GetYN(getString: () => queue.Dequeue()), false);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetYNIEnumerable(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("y");

		Assert.AreEqual(Input.GetYN(new List<string>() { "y", "yes" }, new List<string>() { "n", "no" }, getString: () => queue.Dequeue()), true);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("yes");

		Assert.AreEqual(Input.GetYN(new List<string>() { "y", "yes" }, new List<string>() { "n", "no" }, getString: () => queue.Dequeue()), true);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("n");

		Assert.AreEqual(Input.GetYN(new List<string>() { "y", "yes" }, new List<string>() { "n", "no" }, getString: () => queue.Dequeue()), false);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("no");

		Assert.AreEqual(Input.GetYN(new List<string>() { "y", "yes" }, new List<string>() { "n", "no" }, getString: () => queue.Dequeue()), false);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetYNStrict(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("y");

		Assert.AreEqual(Input.GetYNStrict(getString: () => queue.Dequeue()), true);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("yes");
		queue.Enqueue("n");

		Assert.AreEqual(Input.GetYNStrict(getString: () => queue.Dequeue()), false);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("n");

		Assert.AreEqual(Input.GetYNStrict(getString: () => queue.Dequeue()), false);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("no");
		queue.Enqueue("y");

		Assert.AreEqual(Input.GetYNStrict(getString: () => queue.Dequeue()), true);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetOption(int n)
	{
		List<string> choices = new() { "red", "orange", "yellow", "green", "blue", "purple" };

		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("red");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue()), "red");

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Purple");
		queue.Enqueue("purple");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue()), "purple");

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("h");
		queue.Enqueue("Yellow");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue(), caseSensitive: false), "yellow");

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Blue");
		queue.Enqueue("blue");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue(), caseSensitive: false), "blue");
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetOptionT(int n)
	{
		List<string> choices = new() { "red", "orange", "yellow", "green", "blue", "purple" };

		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("red");

		Assert.AreEqual(Input.GetOption(choices, s => choices.IndexOf(s), getString: () => queue.Dequeue()), 0);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Purple");
		queue.Enqueue("purple");

		Assert.AreEqual(Input.GetOption(choices, s => choices.IndexOf(s), getString: () => queue.Dequeue()), 5);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("h");
		queue.Enqueue("Yellow");

		Assert.AreEqual(Input.GetOption(choices, s => choices.IndexOf(s), getString: () => queue.Dequeue(), caseSensitive: false), 2);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Blue");
		queue.Enqueue("blue");

		Assert.AreEqual(Input.GetOption(choices, s => choices.IndexOf(s), getString: () => queue.Dequeue(), caseSensitive: false), 4);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetOptionDictionary(int n)
	{
		Dictionary<string, int> choices = new()
		{
			["red"] = 0,
			["orange"] = 1,
			["yellow"] = 2,
			["green"] = 3,
			["blue"] = 4,
			["purple"] = 5
		};

		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("red");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue()), 0);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Purple");
		queue.Enqueue("purple");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue()), 5);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("h");
		queue.Enqueue("Yellow");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue(), caseSensitive: false), 2);

		queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("Blue");
		queue.Enqueue("blue");

		Assert.AreEqual(Input.GetOption(choices, getString: () => queue.Dequeue(), caseSensitive: false), 4);
	}
}