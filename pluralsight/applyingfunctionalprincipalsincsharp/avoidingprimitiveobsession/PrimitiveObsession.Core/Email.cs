namespace PrimitiveObsession.Core
{
    public class Email
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Result.Fail<Email>("Email cannot be null or empty");
            }

            return Result.Ok<Email>(new Email(value));
        }
    }
}