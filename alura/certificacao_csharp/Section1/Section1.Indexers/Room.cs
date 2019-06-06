using System.Collections.Generic;

namespace Section1.Indexers
{
    public class Room
    {
        private readonly IDictionary<string, string> _chairs = new Dictionary<string, string>();

        public string this[string chair]
        {
            get
            {
                return _chairs[chair];
            }
            set
            {
                _chairs[chair] = value;
            }
        }
    }
}