using System.Collections.Generic;

namespace NorthwindGraphQL.Entities
{
    public class EmployeeTerritory
    {
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }
        public List<Employee> Employees { get; set; }
        public Territory Territories { get; set; }
    }
}
