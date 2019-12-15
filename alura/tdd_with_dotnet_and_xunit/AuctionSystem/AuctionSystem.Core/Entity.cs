using System;
using System.Collections.Generic;

namespace AuctionSystem.Core
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public override bool Equals(object obj)
        {
            return obj is Entity entity && Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
