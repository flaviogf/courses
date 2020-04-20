using System;

namespace FunctionalPrinciples.AvoidingNulls.Core
{
    public struct Maybe<T> where T : class
    {
        private T _value;

        public T Value
        {
            get
            {
                if (HasNoValue)
                {
                    throw new InvalidOperationException();
                }

                return _value;
            }
        }

        public bool HasValue => _value != null;

        public bool HasNoValue => !HasValue;

        private Maybe(T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
}