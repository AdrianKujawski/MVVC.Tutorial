using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Tutorial.Command;
using MVVM.Tutorial.Model;

namespace MVVM.Tutorial.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; }
        public ICommand UpdateCommand { get; }

        public CustomerViewModel(Customer customer)
        {
            Customer = customer;
            UpdateCommand = new CustomerUpdateCommand(this);
        }

        public void SaveChanges()
        {
            Console.WriteLine($@"{Customer.Name} was saved.");
        }
    }
}
