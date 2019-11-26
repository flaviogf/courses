using System;

namespace Section10.CreateAndApplyAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DetailedReportAttribute : Attribute
    {
        public DetailedReportAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }
}
