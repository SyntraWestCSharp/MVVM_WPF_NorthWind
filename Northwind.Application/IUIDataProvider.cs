using System;
using System.Collections.Generic;
using Northwind.Data;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
    }
}
