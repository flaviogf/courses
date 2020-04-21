using HandlingFailures.Core;
using System;

namespace HandlingFailures.UI
{
    public class UnitOfWork : IUnitOfWork
    {
        public Result Commit()
        {
            Console.WriteLine("UnitOfWork: Commiting");

            return Result.Ok();
        }
    }
}
