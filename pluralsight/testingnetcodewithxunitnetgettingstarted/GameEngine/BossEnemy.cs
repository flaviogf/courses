namespace GameEngine
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(string name = null)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override double TotalSpecialPower => 1000;

        public override double SpecialPowerUses => 6;
    }
}
