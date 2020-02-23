using SkPatelNet.Core.Data;
using SkPatelNet.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkPatelNet.Services.Customers
{
    public partial class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Customer> GetCustomers()
        {
            return _customerRepository.Data.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
