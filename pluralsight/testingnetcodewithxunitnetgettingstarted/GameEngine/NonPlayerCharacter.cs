using System;

namespace GameEngine
{
    public class NonPlayerCharacter
    {
        public NonPlayerCharacter()
        {
            Health = 100;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }
    }
}
