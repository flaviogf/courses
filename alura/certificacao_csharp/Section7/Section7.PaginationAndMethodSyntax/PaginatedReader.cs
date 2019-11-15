using System;

namespace Section7.PaginationAndMethodSyntax
{
    public class PassedToNextPageEventArgs : EventArgs
    {
        public PassedToNextPageEventArgs(int skip, int take, int page)
        {
            Skip = skip;
            Take = take;
            Page = page;
        }

        public int Skip { get; }

        public int Take { get; }

        public int Page { get; set; }
    }

    public class PaginatedReader
    {
        private int _page;

        private readonly int _perPage;

        private readonly int _count;

        public event EventHandler<PassedToNextPageEventArgs> PassedToNextPage;

        public PaginatedReader(int perPage, int count)
        {
            _perPage = perPage;
            _count = count;
            _page = 1;
        }

        public void Read()
        {
            while (HasNextPage())
            {
                var eventArgs = new PassedToNextPageEventArgs(skip: (_page - 1) * _perPage, take: _perPage, page: _page);

                PassedToNextPage?.Invoke(this, eventArgs);

                MoveToNextPage();
            }
        }

        private bool HasNextPage()
        {
            return _page <= Math.Ceiling((double)_count / _perPage);
        }

        private void MoveToNextPage()
        {
            _page++;
        }
    }
}