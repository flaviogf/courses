namespace PrimitiveObsession.Core
{
    public class Name
    {
        public Name(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Result.Fail<Name>("Name cannot be null or empty");
            }

            return Result.Ok<Name>(new Name(value));
        }
    }
}