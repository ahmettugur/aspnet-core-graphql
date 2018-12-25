using NorthwindGraphQL.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Core.Contracts.Repository
{
    public interface IGenericWriteRepository<T>
        where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);

    }
}
