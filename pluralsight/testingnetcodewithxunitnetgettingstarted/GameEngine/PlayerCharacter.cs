using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameEngine
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        private int _health;

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

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;

                OnPropertyChanged();
            }
        }

        public string Nickname { get; set; }

        public IEnumerable<string> Weapons { get; set; }

        public event EventHandler<EventArgs> PlayerSlept;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Sleep()
        {
            Health += CalulateHealthIncrease();

            OnPlayerSlept(EventArgs.Empty);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }

        private int CalulateHealthIncrease()
        {
            var rnd = new Random();

            return rnd.Next(1, 101);
        }

        private void OnPlayerSlept(EventArgs args)
        {
            PlayerSlept?.Invoke(this, args);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
