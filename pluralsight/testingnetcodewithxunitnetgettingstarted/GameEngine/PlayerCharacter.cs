using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            IsNoob = true;
            Health = 100;
            Weapons = new string[] { "Long Bow", "Short Bow", "Short Sword" };
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsNoob { get; set; }

        public int Health { get; set; }

        public string Nickname { get; set; }

        public IEnumerable<string> Weapons { get; set; }

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
