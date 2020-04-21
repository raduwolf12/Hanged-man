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

namespace Spanzuratoarea
{
    /// <summary>
    /// Interaction logic for SingIn.xaml
    /// </summary>
    public partial class SingIn : Window
    {
        public SingIn()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "Jerry" , Img = "E:/MVP/Spanzuratoarea/Spanzuratoarea/Images/jerry.jpg"});
            items.Add(new User() { Name = "Tom", Img= "E:/MVP/Spanzuratoarea/Spanzuratoarea/Images/tom.jpg" });
            listView.ItemsSource = items;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image image1 = Image.FromFile("c:\\FakePhoto1.jpg");

            image.Source = ((User)sender).Img;
        }
    }
}
