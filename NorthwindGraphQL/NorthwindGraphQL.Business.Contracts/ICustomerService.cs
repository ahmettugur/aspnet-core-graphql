using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface ICustomerService
    {
        List<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null);
        Customer Get(Expression<Func<Customer, bool>> predicate);
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        int Delete(Customer entity);
    }
}
