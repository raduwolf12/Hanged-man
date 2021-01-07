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
using Spanzuratoarea.Model;
using System.Drawing;
using Spanzuratoarea.View;

namespace Spanzuratoarea
{
    /// <summary>
    /// Interaction logic for SingIn.xaml
    /// </summary>
    public partial class SingIn : Window
    {
        List<User> items = new List<User>();

        internal List<User> Items { get => items; set => items = value; }

        public SingIn()
        {
            InitializeComponent();
             

            Items.Add(new User() { Name = "Jerry" , Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/jerry.jpg", UriKind.Absolute)) });
            Items.Add(new User() { Name = "Tom", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images / tom.jpg", UriKind.Absolute)) }); 
            Items.Add(new User() { Name = "Scooby Doo",  Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/scooby.jpg", UriKind.Absolute)) });
            Items.Add(new User() { Name = "Shaggy", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/shaggy.jpg", UriKind.Absolute)) }); 

            listView.ItemsSource = Items;
            listView.DataContext = this;
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((User)((ListView)sender).SelectedItem != null))
            {
                image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + ((User)((ListView)sender).SelectedItem).Img, UriKind.Absolute));
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            
                NewUser objs = new NewUser();
                objs.Show();
            
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Items.RemoveAt(listView.SelectedIndex);
            listView.ItemsSource = null;
            listView.ItemsSource = Items;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameView gameObj = new GameView();
            gameObj.Show();
        }
    }
}
