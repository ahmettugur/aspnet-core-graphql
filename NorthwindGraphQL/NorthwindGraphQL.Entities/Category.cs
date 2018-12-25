using NorthwindGraphQL.Core.Contracts.Entities;
using System.Collections.Generic;

namespace NorthwindGraphQL.Entities
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public List<Product> Products { get; set; }
    }
}
