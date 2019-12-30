using System.Collections.Generic;
using System.Linq;
using Northwind.Data;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        public IList<Customer> GetCustomers()
        {
            return new northwindEntities().Customers.ToList();
        }
    }
}
