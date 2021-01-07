using Spanzuratoarea.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spanzuratoarea.View
{
    /// <summary>
    /// Interaction logic for SingInWindowView.xaml
    /// </summary>
    public partial class SingInWindowView : Window
    {
        public SingInWindowView()
        {
            InitializeComponent();
            SingInViewModel vm = new SingInViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

    
    }
}
