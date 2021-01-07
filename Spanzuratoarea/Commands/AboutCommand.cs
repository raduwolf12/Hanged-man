using Spanzuratoarea.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spanzuratoarea.Commands
{
    class AboutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public StudentAbout studentAbout;
        public AboutCommand(StudentAbout studentAbout)
        {
            this.studentAbout = studentAbout;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            studentAbout.Show();
        }
    }
}
