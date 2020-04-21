namespace HandlingFailures.Core
{
    public interface ICommand<T> where T : IInput
    {
        Result Execute(T input);
    }
}
