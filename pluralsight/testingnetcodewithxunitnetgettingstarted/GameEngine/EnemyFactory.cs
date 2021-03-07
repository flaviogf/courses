namespace GameEngine
{
    public class EnemyFactory
    {
        public Enemy Create(string name, bool isBoss = false)
        {
            if (isBoss)
            {
                return new BossEnemy(name);
            }

            return new NormalEnemy(name);
        }
    }
}
