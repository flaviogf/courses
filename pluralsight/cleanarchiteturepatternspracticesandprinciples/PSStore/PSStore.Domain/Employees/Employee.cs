using System;

namespace PSStore.Domain.Employees
{
    public class Employee : IEntity
    {
        internal Employee()
        {
        }

        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}
