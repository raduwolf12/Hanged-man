using Microsoft.Win32;
using Spanzuratoarea.ViewModel;
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

namespace Spanzuratoarea.View
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        //private DirectoryInfo dirInfo;
        //private FileInfo[] info;
        //private int Index;

        public NewUser()
        {
            InitializeComponent();
            NewUserViewModel vm = new NewUserViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
            //dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Images");

            //info = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            //image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(0), UriKind.Absolute));
            //Index = 0;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        if (openFileDialog.ShowDialog() == true)
        //        {
        //            Uri fileUri = new Uri(openFileDialog.FileName);
        //            image.Source = new BitmapImage(fileUri);
        //        }

        //}

        //private void Button1_Copy_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Index < info.Length-1)
        //    {
        //        Index++;
        //        image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute));
        //    }
        //}

        //private void Button1_Click(object sender, RoutedEventArgs e)
        //{
        //    if(Index>0)
        //    {
        //        Index--;
        //        image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute));
        //    }

        //}

        //private void Button2_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void Button3_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
