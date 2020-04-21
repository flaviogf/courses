using HandlingFailures.Core;
using System;

namespace HandlingFailures.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUnitOfWork uow = new UnitOfWork();

            ICustomerRepository customerRepository = new InMemoryCustomerRepository();

            IPaymentGateway paymentGateway = new PagarMePaymentGateway();

            ILog log = new ConsoleLog();

            ICommand<RefillBalanceInput> command = new RefillBalanceCommand(uow, customerRepository, paymentGateway, log);

            Result result = command.Execute(new RefillBalanceInput(1, 150.00M));

            if (result.IsFailure)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("It has been executed successfully");
                Console.ResetColor();
            }
        }
    }
}
