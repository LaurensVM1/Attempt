namespace Attempt;

/// <summary>
/// Represents the result of an operation that can either succeed with a value
/// or fail with an error, without using exceptions for control flow.
/// </summary>
/// <typeparam name="T">The type of the successful result value.</typeparam>
public readonly struct Attempt<T>
{
    /// <summary>
    /// Gets a value indicating whether the attempt succeeded.
    /// </summary>
    public bool Succeeded { get; }

    /// <summary>
    /// Gets a value indicating whether the attempt failed.
    /// </summary>
    public bool Failed => !Succeeded;

    /// <summary>
    /// Gets the value produced by a successful attempt.
    /// Accessing this property is only valid when <see cref="Succeeded"/> is true.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Gets the error produced by a failed attempt.
    /// Accessing this property is only valid when <see cref="Failed"/> is true.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Initializes a successful <see cref="Attempt{T}"/> with the specified value.
    /// </summary>
    /// <param name="value">The value produced by the successful operation.</param>
    private Attempt(T value)
    {
        Value = value;
        Succeeded = true;
        Error = default!;
    }

    /// <summary>
    /// Initializes a failed <see cref="Attempt{T}"/> with the specified error.
    /// </summary>
    /// <param name="error">The error describing the failure.</param>
    private Attempt(Error error)
    {
        Value = default!;
        Error = error;
        Succeeded = false;
    }

    /// <summary>
    /// Deconstructs the attempt into its value and error components,
    /// enabling tuple-style usage.
    /// </summary>
    /// <param name="value">
    /// The successful value if the attempt succeeded; otherwise the default value.
    /// </param>
    /// <param name="error">
    /// The error if the attempt failed; otherwise the default value.
    /// </param>
    public void Deconstruct(out T value, out Error error)
    {
        value = Value;
        error = Error;
    }

    /// <summary>
    /// Creates a successful <see cref="Attempt{T}"/> containing the specified value.
    /// </summary>
    /// <param name="value">The value produced by the successful operation.</param>
    /// <returns>A successful <see cref="Attempt{T}"/>.</returns>
    public static Attempt<T> Ok(T value) => new(value);

    /// <summary>
    /// Creates a failed <see cref="Attempt{T}"/> containing the specified error.
    /// </summary>
    /// <param name="error">The error describing the failure.</param>
    /// <returns>A failed <see cref="Attempt{T}"/>.</returns>
    public static Attempt<T> Fail(Error error) => new(error);

    /// <summary>
    /// Executes an asynchronous operation and captures its result as an <see cref="Attempt{T}"/>.
    /// Any exception thrown by the operation is caught and returned as a failed attempt.
    /// </summary>
    /// <param name="func">The asynchronous operation to execute.</param>
    /// <returns>
    /// A task that resolves to a successful <see cref="Attempt{T}"/> if the operation completes,
    /// or a failed <see cref="Attempt{T}"/> if an exception is thrown.
    /// </returns>
    public static async Task<Attempt<T>> AttemptAsync(Func<Task<T>> func)
    {
        try
        {
            var value = await func();
            return Ok(value);
        }
        catch (Exception ex)
        {
            return Fail(new Error(ex.Message, ex));
        }
    }
}
