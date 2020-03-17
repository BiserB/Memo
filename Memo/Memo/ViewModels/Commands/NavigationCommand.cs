using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Memo.ViewModels.Commands
{
    public class NavigationCommand : ICommand
    {
        private HomeVM homeVM;

        public NavigationCommand(HomeVM homeVM)
        {
            this.homeVM = homeVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.homeVM.Navigate();
        }
    }
}
