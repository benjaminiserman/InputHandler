using InputHandler;

// This is a basic calculator app making use of InputHandler.

// Input the starting number
Console.WriteLine("Please choose your starting number.");
double currentValue = Input.Get(s => double.Parse(s));

// Input the calculator mode (Mode enum is defined at bottom)
Console.WriteLine("Would you like to perform the (same) operation each time, or a (different) operation each time?");
Mode chosenMode = Input.GetOption<Mode>();

// Input whether or not to display intermediate values
Console.WriteLine("Would you like each intermediate value to be displayed (y/n)?");
bool displayIntermediate = Input.GetYN();

// Operations dictionary. Keyed by possible options for user input.
Func<double, double, double>? currentOperation = null;
List<string> stopOptions = new() { "end", "stop", "exit", "quit", "shutdown", "done", "null", "break", "return", "result" };
Dictionary<List<string>, Func<double, double, double>?> operations = new()
{
	[new() { "add", "sum", "+", "plus" }] = (double a, double b) => a + b,
	[new() { "minus", "subtract", "-" }] = (double a, double b) => a - b,
	[new() { "multiply", "times", "x", "*", "product" }] = (double a, double b) => a * b,
	[new() { "divide", "quotient", "/", "fraction" }] = (double a, double b) => a / b,
	[new() { "to the power of", "to the power", "power", "pow", "exp", "exponent", "^" }] = (double a, double b) => Math.Pow(a, b),
	[stopOptions] = null
};

while (true)
{
	if (chosenMode == Mode.Different || currentOperation is null)
	{
		// Input next operation.
		Console.WriteLine("What kind of operation would you like to do?");
		currentOperation = Input.GetOption(operations);
	}

	if (currentOperation is null) break;

	Console.WriteLine("Input a number or (end).");
	double? next = Input.Get<double?>(s =>
	{
		if (stopOptions.Contains(s)) return null;
		else return double.Parse(s);
	});

	if (next is double x) currentValue = currentOperation(currentValue, x);
	else break;

	if (displayIntermediate) Console.WriteLine(currentValue);
}

Console.WriteLine($"Your final value is: {currentValue}");

enum Mode
{
	Same, Different
}