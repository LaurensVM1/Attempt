# Attempt
Attempt is a lightweight, Go-inspired result type that lets you handle success and failure explicitly

# Attempt

**Explicit, Go-style error handling for C#**

`Attempt<T>` represents the result of an operation that can either succeed with a value or fail with an error — without using exceptions for control flow.

```csharp

// Example operation that can fail
static Attempt<int> Divide(int a, int b)
{
    if (b == 0)
        return Attempt<int>.Fail(new Error("Division by zero"));

    return Attempt<int>.Ok(a / b);
}

## Synchronous example
Attempt<int> result = Divide(8, 0);

if (result.Failed)
    Console.WriteLine(result.Error);
else
    Console.WriteLine(result.Value);

## Asynchronous example
var result = await Attempt<User>.AttemptAsync(async () =>
{
    return await LoadUserAsync(userId);
});

if (result.Failed)
    Console.WriteLine(result.Error);
