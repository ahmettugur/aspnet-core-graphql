using NorthwindGraphQL.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Core.Contracts.Repository
{
    public interface IGenericReadRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
    }
}
