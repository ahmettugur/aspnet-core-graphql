using NorthwindGraphQL.Core.Contracts.Repository;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface IOrderService
    {
        List<Order> GetAll(Expression<Func<Order, bool>> predicate = null);
        Order Get(Expression<Func<Order, bool>> predicate);
        Order Add(Order entity);
        Order Update(Order entity);
        int Delete(Order entity);
    }
}
