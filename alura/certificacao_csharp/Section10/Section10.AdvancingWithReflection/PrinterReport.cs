using System.Threading.Tasks;

namespace Section10.AdvancingWithReflection
{
    public class PrinterReport : IReport
    {
        public Task Print()
        {
            return Task.CompletedTask;
        }
    }
}