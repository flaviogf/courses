namespace HandlingFailures.Core
{
    public struct Maybe<T> where T : class
    {
        private Maybe(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public bool HasValue => Value != null;

        public bool HasNoValue => !HasValue;

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
}