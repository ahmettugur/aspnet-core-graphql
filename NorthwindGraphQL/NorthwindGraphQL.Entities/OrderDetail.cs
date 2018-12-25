using System.Collections.Generic;

namespace NorthwindGraphQL.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        public Order Orders { get; set; }
        public List<Product> Products { get; set; }
    }


}
