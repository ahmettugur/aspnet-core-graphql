using NorthwindGraphQL.Core.Contracts.Repository;
using NorthwindGraphQL.Core.Repository.EntityFramework;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Data.EntityFramework.Concrete
{
    public class EFCategoryRepository : EFGenericRepository<Category, NorthwindDbContext>, ICategoryRepository
    {
    }
}
