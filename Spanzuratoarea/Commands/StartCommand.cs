using Spanzuratoarea.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spanzuratoarea.Commands
{
    class StartCommand : ICommand
    {
        public GameView gameObj { get; set; }


        public StartCommand(GameView gameObj)
        {
            this.gameObj = gameObj;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.gameObj.Show();
        }
    }
}
