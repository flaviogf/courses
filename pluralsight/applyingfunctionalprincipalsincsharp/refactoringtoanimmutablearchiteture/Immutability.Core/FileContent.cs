namespace Immutability.Core
{
    public struct FileContent
    {
        public FileContent(string fileName, string[] content)
        {
            FileName = fileName;
            Content = content;
        }

        public string FileName { get; }

        public string[] Content { get; }
    }
}