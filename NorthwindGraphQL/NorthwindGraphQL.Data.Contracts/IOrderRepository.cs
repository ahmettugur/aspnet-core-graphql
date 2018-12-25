using NorthwindGraphQL.Core.Contracts.Repository;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Data.Contracts
{
    public interface IOrderRepository:IGenericWriteRepository<Order>, IGenericReadRepository<Order>
    {
    }
}
