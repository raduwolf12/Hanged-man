using Spanzuratoarea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Spanzuratoarea.ViewModel
{
    class StatisticsViewModel:BaseVM
    {

        Label label1 { set; get; }
        Label label2 { set; get; }
        Label label3 { set; get; }
        Label label4 { set; get; }
        Label label5 { set; get; }
        Label label6 { set; get; }

        Label label7 { set; get; }
        Label label8 { set; get; }
        Label label9 { set; get; }
        Label label10 { set; get; }
        Label label11 { set; get; }
        Label label12 { set; get; }
        Label userLabel { set; get; }

        public Label L1
        {
            get
            {
                return label1;
            }
            set
            {
                label1 = value;
                OnPropertyChanged("L1");
            }
        }
        public Label L2
        {
            get
            {
                return label2;
            }
            set
            {
                label2 = value;
                OnPropertyChanged("L2");
            }
        }
        public Label L3
        {
            get
            {
                return label3;
            }
            set
            {
                label3 = value;
                OnPropertyChanged("L3");
            }
        }
        public Label L4
        {
            get
            {
                return label4;
            }
            set
            {
                label4 = value;
                OnPropertyChanged("L4");
            }
        }
        public Label L5
        {
            get
            {
                return label5;
            }
            set
            {
                label5 = value;
                OnPropertyChanged("L5");
            }
        }
        public Label L6
        {
            get
            {
                return label6;
            }
            set
            {
                label6 = value;
                OnPropertyChanged("L6");
            }
        }

        public Label L7
        {
            get
            {
                return label1;
            }
            set
            {
                label7 = value;
                OnPropertyChanged("L7");
            }
        }
        public Label L8
        {
            get
            {
                return label8;
            }
            set
            {
                label8 = value;
                OnPropertyChanged("L8");
            }
        }
        public Label L9
        {
            get
            {
                return label9;
            }
            set
            {
                label9 = value;
                OnPropertyChanged("L9");
            }
        }
        public Label L10
        {
            get
            {
                return label10;
            }
            set
            {
                label10 = value;
                OnPropertyChanged("L10");
            }
        }
        public Label L11
        {
            get
            {
                return label11;
            }
            set
            {
                label11 = value;
                OnPropertyChanged("L11");
            }
        }
        public Label L12
        {
            get
            {
                return label12;
            }
            set
            {
                label12 = value;
                OnPropertyChanged("L12");
            }
        }
        public Label UserLabel
        {
            get
            {
                return userLabel;
            }
            set
            {
                userLabel = value;
                OnPropertyChanged("L12");
            }
        }
        public User user { set; get; }
        public List<String> userData { set; get; }
        public StatisticsViewModel()
        {
            userData = LoadUserData();
            createUser();
            userLabel = new Label();
            userLabel.Content = user.Name;

            Win();
            Lose();
            

            L1 = new Label();
            L2 = new Label();
            L3 = new Label();
            L4 = new Label();
            L5 = new Label();
            L6 = new Label();
            L7 = new Label();
            L8 = new Label();
            L9 = new Label();
            L10 = new Label();
            L11 = new Label();
            L12 = new Label();
            

            L1.Content = AllW;
            L2.Content = CapW;
            L3.Content = CarsW;
            L4.Content = MountW;
            L5.Content = MovW;
            L6.Content = RivW;

            L7.Content = AllL;
            L8.Content = CapL;
            L9.Content = CarsL;
            L10.Content = MountL;
            L11.Content = MovL;
            L12.Content = RivL;


        }

        public List<String> LoadUserData()
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../CurentUserData.txt");
            List<String> t = new List<String>();

            while ((line = file.ReadLine()) != null)
            {
                t.Add(line);
            }
            file.Close();
            System.Console.ReadLine();
            return t;
        }

        public void createUser()
        {
            user = new User { Name = userData.ElementAt(0), Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + userData.ElementAt(1), UriKind.Absolute)) };
        }
        public List<String> LoadCategorii()
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../Categorii.txt");
            List<String> t = new List<String>();

            while ((line = file.ReadLine()) != null)
            {
                t.Add(line);
            }
            file.Close();
            System.Console.ReadLine();
            return t;
        }
        public int AllW=0;
        public int AllL=0;

        public int CapW = 0;
        public int CapL = 0;

        public int CarsW = 0;
        public int CarsL = 0;

        public int MountW = 0;
        public int MountL = 0;

        public int MovW = 0;
        public int MovL = 0;

        public int RivW = 0;
        public int RivL = 0;

        public void countW (String val)
        {
            if(val== "_All categories")
            {
                AllW = AllW+1;
            }
            if (val == "_Capitals")
            {
                CapW = CapW + 1;
            }
            if (val == "_Cars")
            {
                CarsW = CarsW + 1;
            }
            if (val == "_Mountains")
            {
                MountW = MountW + 1;
            }
            if (val == "_Movies")
            {
                MovW = MovW + 1;

            }
            if (val == "_Rivers")
            {
                RivW = RivW + 1;
            }

        }

        public void countL(String val)
        {
            if (val == "_All categories")
            {
                AllL = AllL + 1;
            }
            if (val == "_Capitals")
            {
                CapL = CapL + 1;
            }
            if (val == "_Cars")
            {
                CarsL = CarsL + 1;
            }
            if (val == "_Mountains")
            {
                MountL = MountL + 1;
            }
            if (val == "_Movies")
            {
                MovL = MovL + 1;

            }
            if (val == "_Rivers")
            {
                RivL = RivL + 1;
            }

        }

        public void Win()
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(user.Name+"_Win.txt");
           
            while ((line = file.ReadLine()) != null)
            {
                countW(line);
            }
            file.Close();
            System.Console.ReadLine();
            
        }

        public void Lose()
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(user.Name + "_Lose.txt");

            while ((line = file.ReadLine()) != null)
            {
                countL(line);
            }
            file.Close();
            System.Console.ReadLine();

        }

    }
}
