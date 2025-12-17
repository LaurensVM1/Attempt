using Attempt;

// Example operation that can fail
static Attempt<int> Divide(int a, int b)
{
    if (b == 0)
        return Attempt<int>.Fail(new Error("Division by zero"));

    return Attempt<int>.Ok(a / b);
}

Console.WriteLine("=== Simple failure handling ===");

var result = Divide(8, 0);

if (result.Failed)
{
    Console.WriteLine($"Operation failed: {result.Error}");
}
else
{
    Console.WriteLine($"Result: {result.Value}");
}

Console.WriteLine();
Console.WriteLine("=== Successful operation ===");

var success = Divide(8, 4);

if (success.Succeeded)
{
    Console.WriteLine($"Result: {success.Value}");
}

Console.WriteLine();
Console.WriteLine("=== Tuple-style deconstruction ===");

result = Divide(10, 2);
var (value, error) = result;

if (result.Failed)
{
    Console.WriteLine($"Error: {error}");
}
else
{
    Console.WriteLine($"Value: {value}");
}