using System;

namespace HandlingFailures.Core
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string error) where T : class
        {
            if (maybe.HasNoValue)
            {
                return Result.Fail<T>(error);
            }

            return Result.Ok<T>(maybe.Value);
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }

        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (result.IsSuccess)
            {
                return func();
            }

            return result;
        }

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result OnBoth(this Result result, Action action)
        {
            action();

            return result;
        }
    }
}
