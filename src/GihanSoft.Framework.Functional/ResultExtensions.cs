using LanguageExt.Common;

namespace GihanSoft.Framework.Functional;

public static class ResultExtensions
{
    public static Either<Exception, TRight> ToEither<TRight>(this Result<TRight> result) => result.Match(
        Right<Exception, TRight>,
        Left<Exception, TRight>);

    public static Result<TRight> ToResult<TRight>(this Either<Exception, TRight> either) => either.Match(
        r => new Result<TRight>(r),
        exp => new Result<TRight>(exp));
}
