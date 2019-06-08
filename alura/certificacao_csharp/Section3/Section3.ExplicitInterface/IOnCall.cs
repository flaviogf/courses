namespace Section3.ExplicitInterface
{
    public interface IOnCall
    {
        event BadgeEventHandler BadgeGenerate;

        int Workload { get; set; }

        void GenerateBadge();
    }
}
