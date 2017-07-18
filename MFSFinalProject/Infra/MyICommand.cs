using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MFSFinalProject.Infra
{
    public class MyICommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public MyICommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }

       



        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
                 CanExecuteChanged(this, EventArgs.Empty);
        }


        // Beware - should use weak references if command instance lifetime 
        //  is longer than lifetime of UI objects that get hooked up to command

        // Prism commands solve this in their implementation public event 
       

    }
}
