using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.Models
{
    public class ProductResponse
    {
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<Product> Products { get; set; }
    }
}
