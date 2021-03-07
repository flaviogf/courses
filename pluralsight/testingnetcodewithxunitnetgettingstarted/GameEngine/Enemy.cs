namespace GameEngine
{
    public abstract class Enemy
    {
        public virtual double TotalSpecialPower { get; }

        public virtual double SpecialPowerUses { get; }

        public double SpecialAttackPower => TotalSpecialPower / SpecialPowerUses;
    }
}
