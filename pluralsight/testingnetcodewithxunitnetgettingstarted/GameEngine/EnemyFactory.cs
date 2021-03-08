using System;

namespace GameEngine
{
    public class EnemyFactory
    {
        public Enemy Create(string name, bool isBoss = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (!isBoss)
            {
                return new NormalEnemy(name);
            }

            if (!name.EndsWith("King") && !name.EndsWith("Queen"))
            {
                throw new EnemyCreationException("BossEnemies should be King or Queen");
            }

            return new BossEnemy(name);
        }
    }
}
