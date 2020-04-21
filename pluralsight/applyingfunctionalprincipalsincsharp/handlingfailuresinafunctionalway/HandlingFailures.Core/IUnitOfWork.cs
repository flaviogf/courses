namespace HandlingFailures.Core
{
    public interface IUnitOfWork
    {
        Result Commit();
    }
}
