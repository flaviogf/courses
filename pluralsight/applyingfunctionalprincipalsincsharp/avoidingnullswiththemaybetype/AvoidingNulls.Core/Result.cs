namespace FunctionalPrinciples.AvoidingNulls.Core
{
    public class Result
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !string.IsNullOrEmpty(Error);

        public string Error { get; }

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        public static Result Fail(string error)
        {
            return new Result(false, error);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(default(T), false, error);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        public Result(T value, bool isSuccess, string error) : base(isSuccess, error)
        {
            Value = value;
        }
    }
}