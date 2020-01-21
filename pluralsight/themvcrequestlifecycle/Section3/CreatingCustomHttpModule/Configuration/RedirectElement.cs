using System.Configuration;

namespace CreatingCustomHttpModule.Configuration
{
    public class RedirectElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get
            {
                return (string)this["key"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("old", IsRequired = true)]
        public string Old
        {
            get
            {
                return (string)this["old"];
            }
            set
            {
                this["old"] = value;
            }
        }

        [ConfigurationProperty("current", IsRequired = true)]
        public string Current
        {
            get
            {
                return (string)this["current"];
            }
            set
            {
                this["current"] = value;
            }
        }
    }
}