namespace Attempt;

/// <summary>
/// Represents an error produced by a failed operation.
/// Contains a human-readable message and an optional underlying exception.
/// </summary>
public readonly struct Error
{
    /// <summary>
    /// Gets a human-readable description of the error.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the underlying exception that caused the error, if available.
    /// This value may be <c>null</c>.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Initializes a new <see cref="Error"/> with the specified error message.
    /// </summary>
    /// <param name="message">A human-readable description of the error.</param>
    public Error(string message)
    {
        Message = message;
        Exception = null;
    }

    /// <summary>
    /// Initializes a new <see cref="Error"/> with the specified message and exception.
    /// </summary>
    /// <param name="message">A human-readable description of the error.</param>
    /// <param name="exception">The exception that caused the error.</param>
    public Error(string message, Exception exception)
    {
        Message = message;
        Exception = exception;
    }

    /// <summary>
    /// Returns the error message.
    /// </summary>
    /// <returns>The value of <see cref="Message"/>.</returns>
    public override string ToString() => Message;
}
