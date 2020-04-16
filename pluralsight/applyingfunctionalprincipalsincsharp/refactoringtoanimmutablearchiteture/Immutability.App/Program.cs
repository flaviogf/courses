using System;
using Immutability.Core;

namespace Immutability.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new AuditManager(5);

            manager.AddRecord("Audit_1.txt", "flavio", DateTime.Now);
        }
    }
}
