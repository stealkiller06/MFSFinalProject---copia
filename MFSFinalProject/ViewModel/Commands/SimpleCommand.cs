using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MFSFinalProject.ViewModel.Commands
{
    public class SimpleCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        public CategoryViewModel CategoryViewModel { get; set; }

        public SimpleCommand(CategoryViewModel categoryViewModel)
        {
            this.CategoryViewModel = categoryViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
