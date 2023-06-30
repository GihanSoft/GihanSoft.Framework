using LanguageExt.Common;

namespace GihanSoft.Framework.Functional;

public static class ResultExtensions
{
    public static Either<Exception, TRight> ToEither<TRight>(this Result<TRight> result)
    {
        return result.Match(Right<Exception, TRight>, Left<Exception, TRight>);
    }
}
