using System.Runtime.Serialization;

namespace GihanSoft.Framework.Functional;

[Serializable]
public class ProblemException : Exception
{
    public ProblemException() { }

    public ProblemException(string? message) : base(message) { }

    public ProblemException(string? message, Exception? innerException) : base(message, innerException) { }

    protected ProblemException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public required int StatusCode { get; init; }
    public string? ProblemType { get; init; }
    public string? Title { get; init; }
    public string? Detail { get; init; }
    public string? Instance { get; init; }
    public IDictionary<string, object?>? Extensions { get; init; }
}
