using System.Configuration;

namespace CreatingCustomHttpModule.Configuration
{
    public class RedirectElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RedirectElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RedirectElement)element).Key;
        }
    }
}