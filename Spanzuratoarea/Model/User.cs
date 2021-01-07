using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Spanzuratoarea.Model
{
    class User
    {
        private string name;
        private BitmapImage img;
        public BitmapImage Img { get => img; set => img = value; }
        public string Name { get => name; set => name = value; }
    }
}
