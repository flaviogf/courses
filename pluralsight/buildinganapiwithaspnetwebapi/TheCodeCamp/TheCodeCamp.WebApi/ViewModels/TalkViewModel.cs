namespace TheCodeCamp.WebApi.ViewModels
{
    public class TalkViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public int Level { get; set; }

        public SpeakerViewModel Speaker { get; set; }
    }
}