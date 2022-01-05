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
}