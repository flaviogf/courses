using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Immutability.Core
{
    public class AuditManager
    {
        private readonly int _maxEntriesPerFile;

        public AuditManager(int maxEntriesPerFile)
        {
            _maxEntriesPerFile = maxEntriesPerFile;
        }

        [Obsolete]
        public void AddRecord(string currentFile, string visitorName, DateTime timeOfVisit)
        {
            var lines = File.ReadAllLines(currentFile);

            if (lines.Length < _maxEntriesPerFile)
            {
                var lastIndex = int.Parse(lines.Last().Split(';')[0]);
                var newLine = $"{lastIndex + 1};{visitorName};{timeOfVisit:s}";
                File.AppendAllLines(currentFile, new[] { newLine });
            }
            else
            {
                var newLine = $"1;{visitorName};{timeOfVisit:s}";
                var newFileName = GetNewFileName(currentFile);
                File.WriteAllLines(newFileName, new[] { newLine });
            }
        }

        public FileAction AddRecord(FileContent currentFile, string visitorName, DateTime timeOfVisit)
        {
            IList<AuditEntry> entries = Parse(currentFile.Content);

            if (entries.Count < _maxEntriesPerFile)
            {
                entries.Add(new AuditEntry(entries.Count + 1, visitorName, timeOfVisit));
                var newContent = Serialize(entries);
                return new FileAction(currentFile.FileName, EActionType.Update, newContent);
            }
            else
            {
                var entry = new AuditEntry(1, visitorName, timeOfVisit);
                var newContent = Serialize(new List<AuditEntry> { entry });
                var newFileName = GetNewFileName(currentFile.FileName);
                return new FileAction(newFileName, EActionType.Create, newContent);
            }
        }

        private string GetNewFileName(string currentFile)
        {
            var fileName = Path.GetFileNameWithoutExtension(currentFile);
            var index = int.Parse(fileName.Split('_')[1]);
            return $"Audit_{index + 1}.txt";
        }

        private IList<AuditEntry> Parse(string[] content)
        {
            return content
                .Select(it => it.Split(';'))
                .Select(it => new AuditEntry(int.Parse(it[0]), it[1], DateTime.Parse(it[2]))).ToList();
        }

        private string[] Serialize(IList<AuditEntry> entries)
        {
            return entries
                .Select(it => $"{it.Number};{it.Visitor};{it.TimeOfVisit:s}")
                .ToArray();
        }
    }
}