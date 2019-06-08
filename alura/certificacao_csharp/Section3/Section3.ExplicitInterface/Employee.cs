using System;

namespace Section3.ExplicitInterface
{
    public class Employee : IEmployee, IOnCall
    {
        public event BadgeEventHandler BadgeGenerate;

        int IEmployee.Workload { get; set; }
        int IOnCall.Workload { get; set; }

        void IEmployee.GenerateBadge()
        {
            BadgeGenerate?.Invoke(this, new BadgeEventArgs("employee badge generate"));
        }

        void IOnCall.GenerateBadge()
        {
            BadgeGenerate?.Invoke(this, new BadgeEventArgs("on call badge generate"));
        }
    }
}
