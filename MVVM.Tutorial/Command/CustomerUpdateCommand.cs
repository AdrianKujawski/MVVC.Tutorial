using System;
using System.Windows.Input;
using MVVM.Tutorial.Model;
using MVVM.Tutorial.ViewModel;

namespace MVVM.Tutorial.Command
{
    public class CustomerUpdateCommand : ICommand
    {
        private readonly CustomerViewModel _viewModel;

        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return string.IsNullOrEmpty(_viewModel.Customer.Error);
        }

        public void Execute(object parameter)
        {
            _viewModel.SaveChanges();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
