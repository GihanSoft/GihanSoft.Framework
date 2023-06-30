using LanguageExt.Common;

namespace GihanSoft.Framework.Functional;

public static class ValidationExtensions
{
    public static Either<ValidationException, TSuccess> ToEitherWithValidationExceptionLeft<TSuccess>(
        this Validation<KeyValuePair<string, string>, TSuccess> validation
        )
    {
        return validation.Match(
            Right<ValidationException, TSuccess>,
            (Seq<KeyValuePair<string, string>> errors) => errors
                .GroupBy(x => x.Key, x => x.Value)
                .ToDictionary(x => x.Key, x => x.ToArray(), StringComparer.Ordinal)
                .Apply(e => new ValidationException() { Errors = e })
                .Apply(Left<ValidationException, TSuccess>)
            );
    }

    public static Result<TSuccess> ToResultWithValidationExceptionLeft<TSuccess>(
        this Validation<KeyValuePair<string, string>, TSuccess> validation
        )
    {
        return validation.Match(
            x => new Result<TSuccess>(x),
            (Seq<KeyValuePair<string, string>> errors) => errors
                .GroupBy(x => x.Key, x => x.Value)
                .ToDictionary(x => x.Key, x => x.ToArray(), StringComparer.Ordinal)
                .Apply(e => new ValidationException() { Errors = e })
                .Apply(x => new Result<TSuccess>(x))
            );
    }
}
