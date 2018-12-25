using NorthwindGraphQL.Core.Repository.EntityFramework;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Data.EntityFramework.Concrete
{
    public class EFProductRepository : EFGenericRepository<Product, NorthwindDbContext>, IProductRepository
    {
    }
}
