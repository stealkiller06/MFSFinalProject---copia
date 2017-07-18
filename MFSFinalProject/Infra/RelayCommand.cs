using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MFSFinalProject.Infra
{
    public class RelayCommand : ICommand
    {
        private Action localAction;
        private bool localCanExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action, bool CanExecute)
        {
            localAction = action;
            localCanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return localCanExecute;
        }

        public void Execute(object parameter)
        {
            localAction();
        }
    }
}
