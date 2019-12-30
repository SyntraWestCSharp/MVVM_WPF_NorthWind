using System;
using System.Collections.Generic;
using Northwind.Data;
using System.Data.Entity;

using System.Linq;
using System.Collections.ObjectModel;
using Northwind.Application;

namespace Northwind.ViewModel
{
   
    public class MainWindowViewModel
    {
        public ObservableCollection<ToolViewModel> Tools { get; set; }
        private readonly IUIDataProvider _dataProvider;
        public string Name   { get { return "Northwind"; } }
        public string ControlPanelName   { get { return "Control Panel"; } }
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
        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Tools = new ObservableCollection<ToolViewModel>();
            Tools.Add(new AToolViewModel());
            Tools.Add(new BToolViewModel());
        }
        private void GetCustomers()
        {
            _customers = new northwindEntities().Customers.ToList();
           // int count = _customers.Count;
        }
    }
}
