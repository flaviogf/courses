using System.Threading.Tasks;

namespace PSStore.Application.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        Task Execute(CreateSaleModel model);
    }
}
