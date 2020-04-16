using System;

namespace Immutability.Core
{
    public struct AuditEntry
    {
        public AuditEntry(int number, string visitor, DateTime timeOfVisit)
        {
            Number = number;
            Visitor = visitor;
            TimeOfVisit = timeOfVisit;
        }

        public int Number { get; }

        public string Visitor { get; }

        public DateTime TimeOfVisit { get; }
    }
}