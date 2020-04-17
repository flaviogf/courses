namespace PrimitiveObsession.Core
{
    public class Result
    {
        internal Result(string error)
        {
            Error = error;
        }

        public string Error { get; protected set; }

        public bool IsSuccess => string.IsNullOrEmpty(Error);

        public bool IsFaiulure => !IsSuccess;

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, null);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(default(T), error);
        }
    }

    public class Result<T> : Result
    {
        internal Result(T value, string error) : base(error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}