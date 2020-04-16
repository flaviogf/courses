namespace Immutability.Core
{
    public struct FileAction
    {
        public FileAction(string fileName, EActionType type, string[] content)
        {
            FileName = fileName;
            Type = type;
            Content = content;
        }

        public string FileName { get; }

        public EActionType Type { get; }

        public string[] Content { get; }
    }
}