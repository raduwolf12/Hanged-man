using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using Spanzuratoarea.UserControls;
using Spanzuratoarea.ViewModel;

namespace Spanzuratoarea.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        //private int counter=0;
        //private DirectoryInfo dirInfo;
        //private FileInfo[] info;
        //private int Index;

        //private String test = "TEST";
        //private String result;

        //DispatcherTimer _timer;
        //TimeSpan _time;
        public GameView()
        {
            InitializeComponent();
            GameViewModel vm = new GameViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);

            //_time = TimeSpan.FromSeconds(60);

            //_timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            //{
            //    lblTime.Content = _time.ToString("c");
            //    if (_time == TimeSpan.Zero) _timer.Stop();
            //    _time = _time.Add(TimeSpan.FromSeconds(-1));
            //}, Application.Current.Dispatcher);

            //_timer.Start();
            //dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Images/art");

            //info = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            //image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/art/" + info.ElementAt(0), UriKind.Absolute));
            //Index = 0;

            //for(int i =0;i<test.Length; i++)
            //{
            //    if(test.ElementAt(i)==' ')
            //    {
            //        testArea.Text += "  ";
            //    }
            //    else
            //    {
            //        testArea.Text += " _ ";
            //    }

            //}
            //result = testArea.Text;
        }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {
        //        Button button = (Button)sender;

        //        if (!test.Contains(button.Content.ToString()))
        //        {

        //            if (Index < info.Length - 1)
        //            {
        //                Index++;
        //                image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/art/" + info.ElementAt(Index), UriKind.Absolute));
        //            }
        //            counter++;
        //            display();
        //        }
        //        else
        //        {
        //            refreshAnswer(button.Content.ToString());
        //            button.IsEnabled = false;
        //        }



        //    }
        //    private void display()
        //    {
        //        if(counter==1)
        //        {
        //            L1.Content = "X";
        //        }
        //        if (counter == 2)
        //        {
        //            L2.Content = "X";


        //        }
        //        if (counter == 3)
        //        {
        //            L3.Content = "X";

        //        }
        //        if (counter == 4)
        //        {
        //            L4.Content = "X";

        //        }
        //        if (counter == 5)
        //        {
        //            L5.Content = "X";


        //        }
        //        if (counter == 6)
        //        {
        //            L6.Content = "X";


        //        }



        //    }

        //   private void refreshAnswer(string caracter)
        //    {
        //        string val="";
        //        for (int i = 0; i < test.Length; i++)
        //        {

        //            if (test.ElementAt(i).ToString().Equals(caracter))
        //            {
        //                val += caracter;
        //            }
        //            else
        //            {
        //                val += result.ElementAt(i);
        //            }


        //        }
        //        result = val;
        //        testArea.Text = val;
        //    }
        //}
    }
}
