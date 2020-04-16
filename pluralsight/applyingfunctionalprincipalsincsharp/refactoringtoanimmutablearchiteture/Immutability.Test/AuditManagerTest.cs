using System;
using Immutability.Core;
using Xunit;

namespace Immutability.Test
{
    public class AuditManagerTest
    {
        [Fact]
        public void AddRecord_When_Given_A_New_Entry_Should_Add_It()
        {
            var manager = new AuditManager(10);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;fernando;2020-04-16T08:32:14"
            });

            var action = manager.AddRecord(file, "flavio", new DateTime(2020, 4, 16, 9, 0, 0));

            Assert.Equal(EActionType.Update, action.Type);
            Assert.Equal("Audit_1.txt", action.FileName);
            Assert.Equal(new[]
            {
                "1;fernando;2020-04-16T08:32:14",
                "2;flavio;2020-04-16T09:00:00"
            }, action.Content);
        }

        [Fact]
        public void AddRecord_When_Given_A_New_Entry_And_The_Current_File_Is_Overflowed_Should_Add_It_To_A_New_File()
        {
            var manager = new AuditManager(1);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;fernando;2020-04-16T08:32:14"
            });

            var action = manager.AddRecord(file, "flavio", new DateTime(2020, 4, 16, 9, 0, 0));

            Assert.Equal(EActionType.Create, action.Type);
            Assert.Equal("Audit_2.txt", action.FileName);
            Assert.Equal(new[]
            {
                "1;flavio;2020-04-16T09:00:00"
            }, action.Content);
        }
    }
}