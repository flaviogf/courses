using System;

namespace PSStore.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
