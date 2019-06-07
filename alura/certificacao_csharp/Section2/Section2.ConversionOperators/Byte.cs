namespace Section2.ConversionOperators
{
    public class Byte
    {
        public double Value { get; }

        public Byte(double value)
        {
            Value = value;
        }

        public static implicit operator Byte(double value)
        {
            return new Byte(value);
        }
    }
}