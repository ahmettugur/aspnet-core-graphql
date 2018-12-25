using NorthwindGraphQL.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Entities
{
    public class OrderDetailView:IEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        public decimal ExtendedPrice { get; set; }
    }
}
