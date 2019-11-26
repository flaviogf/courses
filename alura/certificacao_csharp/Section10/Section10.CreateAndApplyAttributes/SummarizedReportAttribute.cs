using System;

namespace Section10.CreateAndApplyAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SummarizedReportAttribute : Attribute
    {
        public SummarizedReportAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }
}
