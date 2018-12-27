using NorthwindGraphQL.Core.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace NorthwindGraphQL.Entities
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        ////public List<Customer> Customers { get; set; }
        //public List<Employee> Employees { get; set; }
    }


}
