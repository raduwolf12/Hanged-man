using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spanzuratoarea.Model
{
    class User
    {
        private string name;
        private string img;

        public string Img { get => img; set => img = value; }
        public string Name { get => name; set => name = value; }
    }
}
