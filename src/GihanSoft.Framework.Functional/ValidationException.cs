namespace GihanSoft.Framework.Functional;

public class ValidationException : Exception
{
    public ValidationException() { }

    public ValidationException(string? message) : base(message) { }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException) { }

    public required IDictionary<string, string[]> Errors { get; init; }
}
