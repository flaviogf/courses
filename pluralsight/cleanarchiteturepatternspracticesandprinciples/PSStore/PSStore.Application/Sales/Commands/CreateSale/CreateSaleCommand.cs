using Microsoft.EntityFrameworkCore;
using PSStore.Domain.Sales;
using System;
using System.Threading.Tasks;

namespace PSStore.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDatabaseGateway _databaseGateway;

        public CreateSaleCommand(IDatabaseGateway databaseGateway)
        {
            _databaseGateway = databaseGateway;
        }

        public async Task Execute(CreateSaleModel model)
        {
            var customer = await _databaseGateway.Customers.SingleAsync(it => it.Id == model.CustomerId);

            var employee = await _databaseGateway.Employees.SingleAsync(it => it.Id == model.EmplyeeId);

            var product = await _databaseGateway.Products.SingleAsync(it => it.Id == model.ProductId);

            var sale = new Sale(Guid.NewGuid(), customer, employee, product, model.Quantity);

            await _databaseGateway.Sales.AddAsync(sale);

            await _databaseGateway.Save();
        }
    }
}
