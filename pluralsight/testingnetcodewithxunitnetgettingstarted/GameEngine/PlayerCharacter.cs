using System;

namespace GameEngine
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            IsNoob = true;
            Health = 100;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsNoob { get; set; }

        public int Health { get; set; }

        public void Sleep()
        {
            Health += CalulateHealthIncrease();
        }

        private int CalulateHealthIncrease()
        {
            var rnd = new Random();

            return rnd.Next(1, 101);
        }
    }
}
