using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface ISupplierService
    {
        List<Supplier> GetAll(Expression<Func<Supplier, bool>> predicate = null);
        Supplier Get(Expression<Func<Supplier, bool>> predicate);
        Supplier Add(Supplier entity);
        Supplier Update(Supplier entity);
        int Delete(Supplier entity);
    }
}
