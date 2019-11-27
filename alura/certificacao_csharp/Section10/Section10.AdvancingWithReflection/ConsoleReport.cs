using System.Threading.Tasks;

namespace Section10.AdvancingWithReflection
{
    public class ConsoleReport : IReport
    {
        public Task Print()
        {
            return Task.CompletedTask;
        }
    }
}