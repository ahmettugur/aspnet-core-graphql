using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface IOrderDetailViewService
    {
        List<OrderDetailView> GetAll(Expression<Func<OrderDetailView, bool>> predicate = null);
        OrderDetailView Get(Expression<Func<OrderDetailView, bool>> predicate);
    }
}
