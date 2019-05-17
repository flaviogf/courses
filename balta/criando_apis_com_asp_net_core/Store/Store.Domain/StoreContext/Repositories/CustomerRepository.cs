namespace Store.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckEmail(string email);
    }
}