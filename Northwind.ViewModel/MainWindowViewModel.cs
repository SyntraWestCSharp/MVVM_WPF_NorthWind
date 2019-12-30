using System;
using System.Collections.Generic;
using Northwind.Data;
using System.Data.Entity;

using System.Linq;

namespace Northwind.ViewModel
{

    public class MainWindowViewModel
    {
        private IList<Customer> _customers;
        public IList<Customer> Customers {
            get {
                if (_customers is null)
                {
                    GetCustomers();
                }
                return _customers;
            }
        }
        private void GetCustomers()
        {
            _customers = new northwindEntities().Customers.ToList();
            int count = _customers.Count;
        }
    }
}
