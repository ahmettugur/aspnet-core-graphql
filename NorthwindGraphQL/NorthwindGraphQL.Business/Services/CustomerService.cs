using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer Add(Customer entity)
        {
            return _customerRepository.Add(entity);
        }

        public int Delete(Customer entity)
        {
            return _customerRepository.Delete(entity);
        }

        public Customer Get(Expression<Func<Customer, bool>> predicate)
        {
            return _customerRepository.Get(predicate);
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null)
        {
            return _customerRepository.GetAll(predicate);
        }

        public Customer Update(Customer entity)
        {
            return _customerRepository.Update(entity);
        }
    }
}
