using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Contracts
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> predicate = null);
        Category Get(Expression<Func<Category, bool>> predicate);
        Category Add(Category entity);
        Category Update(Category entity);
        int Delete(Category entity);
    }
}
