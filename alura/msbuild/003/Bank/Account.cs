namespace Bank
{
    public class Account
    {
        public string Holder { get; set; }

        public override string ToString() => Holder;
    }
}
