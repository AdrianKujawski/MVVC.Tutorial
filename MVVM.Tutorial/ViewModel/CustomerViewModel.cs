using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Tutorial.Command;
using MVVM.Tutorial.Model;
using MVVM.Tutorial.View;

namespace MVVM.Tutorial.ViewModel
{
    public class CustomerViewModel
    {
        private CustomerInfoViewModel _childViewModel;

        public Customer Customer { get; }
        public ICommand UpdateCommand { get; }

        public CustomerViewModel(Customer customer)
        {
            Customer = customer;
            UpdateCommand = new CustomerUpdateCommand(this);
            _childViewModel = new CustomerInfoViewModel();
        }

        public void SaveChanges()
        {
            var customerInfoView = new CustomerInfoView {DataContext = _childViewModel};
            _childViewModel.Info = $"{Customer.Name} was updated in the datebase.";
            customerInfoView.ShowDialog();
        }
    }
}
