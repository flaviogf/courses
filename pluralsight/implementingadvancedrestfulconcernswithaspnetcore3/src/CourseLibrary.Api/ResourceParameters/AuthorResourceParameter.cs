namespace CourseLibrary.Api.ResourceParameters
{
    public class AuthorResourceParameter
    {
        private const int MaxPageSize = 20;

        private int _pageSize = 10;

        public string MainCategory { get; set; }

        public string SearchQuery { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string OrderBy { get; set; } = "Name";

        public string Fields { get; set; }
    }
}
