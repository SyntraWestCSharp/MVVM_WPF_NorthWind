using System.Collections.Generic;
using System.Linq;
using Northwind.Data;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        private northwindEntities _northwindEntities = new northwindEntities();
        public IList<Customer> GetCustomers()
        {
            return new northwindEntities().Customers.ToList();
        }
        public Customer GetCustomer(string customerID)
        {
            return _northwindEntities.Customers.Single(c => c.CustomerID == customerID);
        }
    }
}
