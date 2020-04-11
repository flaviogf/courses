using PSStore.Domain.Sales;
using System;
using System.Threading.Tasks;

namespace PSStore.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IUnitOfWork _uow;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;

        public CreateSaleCommand
        (
            IUnitOfWork uow,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IProductRepository productRepository,
            ISaleRepository saleRepository
        )
        {
            _uow = uow;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }

        public async Task Execute(CreateSaleModel model)
        {
            var customer = await _customerRepository.Get(model.CustomerId);

            var employee = await _employeeRepository.Get(model.EmployeeId);

            var product = await _productRepository.Get(model.ProductId);

            var sale = new Sale
            (
                Guid.NewGuid(),
                customer,
                employee,
                product,
                model.Quantity
            );

            await _saleRepository.Add(sale);

            await _uow.Save();
        }
    }
}
