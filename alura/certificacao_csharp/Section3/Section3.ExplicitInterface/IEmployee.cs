using System;

namespace Section3.ExplicitInterface
{
    public interface IEmployee
    {
        event BadgeEventHandler BadgeGenerate;

        int Workload { get; set; }

        void GenerateBadge();
    }
}
