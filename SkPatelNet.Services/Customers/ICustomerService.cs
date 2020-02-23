using SkPatelNet.Core.Domain.Customers;

namespace SkPatelNet.Services.Customers
{
    public partial interface ICustomerService
    {
        void InsertCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByUserName(string userName);
        Customer GetCustomerBySystemName(string systemName);
    }
}
