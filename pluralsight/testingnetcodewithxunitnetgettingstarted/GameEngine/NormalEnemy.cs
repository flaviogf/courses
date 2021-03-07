namespace GameEngine
{
    public class NormalEnemy : Enemy
    {
        public NormalEnemy(string name = null)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override double TotalSpecialPower => 6;

        public override double SpecialPowerUses => 2;
    }
}
