using System.Configuration;

namespace CreatingCustomHttpModule.Configuration
{
    public class RedirectSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(RedirectElementCollection))]
        public RedirectElementCollection Elements => (RedirectElementCollection)this[""];
    }
}