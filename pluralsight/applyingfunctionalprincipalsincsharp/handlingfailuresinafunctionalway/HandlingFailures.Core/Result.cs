namespace HandlingFailures.Core
{
    public class Result
    {
        public Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public string Error { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result Fail(string error)
        {
            return new Result(false, error);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Result.Ok();
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(default(T), false, error);
        }
    }

    public class Result<T> : Result
    {
        public Result(T value, bool isSuccess, string error) : base(isSuccess, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}