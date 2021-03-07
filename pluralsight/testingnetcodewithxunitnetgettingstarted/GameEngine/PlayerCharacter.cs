namespace GameEngine
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            IsNoob = true;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsNoob { get; set; }
    }
}
