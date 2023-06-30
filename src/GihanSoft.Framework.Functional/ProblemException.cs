using System.Runtime.Serialization;

namespace GihanSoft.Framework.Functional;

[Serializable]
public class ProblemException : Exception
{
    public ProblemException() { }

    public ProblemException(string? message) : base(message) { }

    public ProblemException(string? message, Exception? innerException) : base(message, innerException) { }

    protected ProblemException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public required int Status { get; init; }
    public required string ProblemType { get; init; }
    public string? Title { get; init; }
    public string? Detail { get; init; }
    public string? Instance { get; init; }
    public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>(StringComparer.Ordinal);
}
