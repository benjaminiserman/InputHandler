namespace TestProject;
using System.Collections.Generic;
using InputHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Get_Tests
{
	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void Get(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("7.5");

		double x = 0;

		Input.Get(s => x = double.Parse(s), getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetT(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("7.5");

		double x = Input.Get(s => double.Parse(s), getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetCheck(int n)
	{
		Queue<string> queue = new();
		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("7.5");

		double x = double.Parse(Input.GetCheck(s => double.TryParse(s, out _), getString: () => queue.Dequeue()));

		Assert.AreEqual(x, 7.5);
	}

	[DataTestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(2)]
	[DataRow(5)]
	[DataRow(10)]
	[DataRow(100)]
	public void GetTCheck(int n)
	{
		double x;
		Queue<string> queue = new();

		for (int i = 0; i < n; i++) queue.Enqueue("hi");
		queue.Enqueue("7.5");

		x = Input.GetCheck(s => double.Parse(s), x => x < 10, getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5, "I");

		for (int i = 0; i < n; i++) queue.Enqueue("12.5");
		queue.Enqueue("7.5");

		x = Input.GetCheck(s => double.Parse(s), x => x < 10, getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5, "II");

		for (int i = 0; i < n; i++)
		{
			queue.Enqueue("hi");
			queue.Enqueue("12.5");
		}

		queue.Enqueue("7.5");

		x = Input.GetCheck(s => double.Parse(s), x => x < 10, getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5, "III");

		for (int i = 0; i < n; i++)
		{
			queue.Enqueue("12.5");
			queue.Enqueue("hi");
		}

		queue.Enqueue("7.5");

		x = Input.GetCheck(s => double.Parse(s), x => x < 10, getString: () => queue.Dequeue());

		Assert.AreEqual(x, 7.5, "IV");
	}

	[TestMethod]
	public void GetBool()
	{
		Assert.AreEqual(Input.GetBool(s => char.IsUpper(s[0]), () => "hi"), false);
		Assert.AreEqual(Input.GetBool(s => char.IsUpper(s[0]), () => "Hi"), true);
	}
}