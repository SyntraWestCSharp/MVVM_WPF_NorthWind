using System;
using System.Collections.Generic;
using Northwind.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;
using Northwind.Application;
using System.ComponentModel;
using System.Windows.Data;

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
        public string SelectedCustomerID { get; set; }
        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Tools = new ObservableCollection<ToolViewModel>();

            //Tools.Add(new CustomerDetailsViewModel(_dataProvider, "ALFKI"));
            /*Tools.Add(new AToolViewModel());
            Tools.Add(new BToolViewModel());*/
        }
        private void GetCustomers()
        {
            _customers = new northwindEntities().Customers.ToList();
           // int count = _customers.Count;
        }
        public void ShowCustomerDetails()
        {
            if (string.IsNullOrEmpty(SelectedCustomerID))
                throw new InvalidOperationException("SelectedCustomerID can't be null");
            CustomerDetailsViewModel customerDetailsViewModel = GetCustomerDetailsTool(SelectedCustomerID);
            if (customerDetailsViewModel == null)
            {
                customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
                Tools.Add(customerDetailsViewModel);
            }
            SetCurrentTool(customerDetailsViewModel);
        }
        private CustomerDetailsViewModel GetCustomerDetailsTool(string customerID)
        {
            return Tools
            .OfType<CustomerDetailsViewModel>()
            .FirstOrDefault(c =>
            c.Customer.CustomerID ==
            customerID);
        }
        private void SetCurrentTool(ToolViewModel currentTool)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);
            if (collectionView != null)
            {
                if (collectionView.MoveCurrentTo(currentTool) != true)
                {
                    throw new InvalidOperationException("Could not find the current tool.");
                }
            }
        }
    }
}
