using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace GameEngine
{
    public class GameState
    {
        public const int EarthquakeDamage = 25;

        private readonly IList<PlayerCharacter> _players = new List<PlayerCharacter>();

        public IReadOnlyCollection<PlayerCharacter> Players => new ReadOnlyCollection<PlayerCharacter>(_players);

        public Guid Id { get; }

        public GameState()
        {
            Id = Guid.NewGuid();

            CreateGameWorld();
        }

        public void Add(PlayerCharacter player)
        {
            _players.Add(player);
        }

        public void Earthquake()
        {
            foreach (var it in _players)
            {
                it.TakeDamage(EarthquakeDamage);
            }
        }

        public void Reset()
        {
            _players.Clear();
        }

        private void CreateGameWorld()
        {
            Thread.Sleep(2000);
        }
    }
}
