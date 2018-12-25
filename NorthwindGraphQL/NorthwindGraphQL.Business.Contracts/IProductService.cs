using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> predicate = null);
        Product Get(Expression<Func<Product, bool>> predicate);
        Product Add(Product entity);
        Product Update(Product entity);
        int Delete(Product entity);
    }
}
