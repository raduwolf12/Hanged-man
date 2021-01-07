using Spanzuratoarea.Commands;
using Spanzuratoarea.Model;
using Spanzuratoarea.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Spanzuratoarea.ViewModel
{
    class GameViewModel:BaseVM
    {
        public Window window { set; get; }

        private int counter = 0;
        private DirectoryInfo dirInfo;
        private FileInfo[] info;

        public User user { set; get; }

        Label label1 { set; get; }
        Label label2 { set; get; }
        Label label3 { set; get; }
        Label label4 { set; get; }
        Label label5 { set; get; }
        Label label6 { set; get; }

        public Label L1
        {
            get
            {
                return label1;
            }
            set
            {
                label = value;
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
                label = value;
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
                label = value;
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
                label = value;
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
                label = value;
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
                label = value;
                OnPropertyChanged("L6");
            }
        }


        DispatcherTimer _timer;
        TimeSpan _time;

        Label label { set; get; }
        public Label Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        private BitmapImage image { set; get; }
        public BitmapImage Output
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Output");
            }
        }

        private int Index;

        private String word ;
        private String result;
        public AboutCommand aboutCommand { get; set; }

        public TextBlock tbx { get; set; }

        public TextBlock Tbx
        {
            get
            {
                return tbx;
            }
            set
            {
                tbx = value;
                OnPropertyChanged("Tbx");
            }
        }

        public TextBlock tbx1 { get; set; }

        public TextBlock Tbx1
        {
            get
            {
                return tbx1;
            }
            set
            {
                tbx1 = value;
                OnPropertyChanged("Tbx1");
            }
        }

        public TextBlock tbx2 { get; set; }

        public TextBlock Tbx2
        {
            get
            {
                return tbx2;
            }
            set
            {
                tbx2 = value;
                OnPropertyChanged("Tbx2");
            }
        }

        public TextBlock tbx4 { get; set; }

        public TextBlock Tbx4
        {
            get
            {
                return tbx4;
            }
            set
            {
                tbx4 = value;
                OnPropertyChanged("Tbx4");
            }
        }
        public Action CloseAction { get; set; }
        public int Nivel = 1;
        public GameViewModel()
        {
            window = new Window();
            L1 = new Label();
            aboutCommand = new AboutCommand(new StudentAbout());
            userData = new List<string>();

            dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Images/art");
            info = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            image = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/art/" + info.ElementAt(0), UriKind.Absolute));
            Index = 0;

            Label = new Label();

            _time = TimeSpan.FromSeconds(30);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Label.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    tbx4.Text = "Loss";
                    OnPropertyChanged("tbx4");
                    OnPropertyChanged("tbx4");

                }  
              
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

            user = new User();
            Label7 = new Label();
            userData = LoadUserData(); categories = LoadCategories(); createUser();
            label7.Content = user.Name;
            tbx = new TextBlock();
            tbx.Text = userData.ElementAt(2);
            Tbx1 = new TextBlock();
            tbx1.Text = Nivel.ToString();

            Tbx2 = new TextBlock();
            tbx2.Text = "";
            word = categories.ElementAt(0);
            for (int i = 0; i < word.Length; i++)
            {
                if (word.ElementAt(i) == ' ')
                {
                    tbx2.Text += "  ";
                }
                else
                {
                    tbx2.Text += " _ ";
                }

            }
            result = tbx2.Text;

            Tbx4 = new TextBlock();
            tbx4.Text = "";

        }

     
        private ICommand about;

        public ICommand About => about = new RelayCommand(o=> { StudentAbout studentAbout = new StudentAbout(); studentAbout.Show();} );

        private ICommand buttonCommand;
        public ICommand ButtonCommand => buttonCommand = new RelayCommand(o=> { Button_Click(o); });

        private ICommand start;
        public ICommand Start => start = new RelayCommand(o => {  GameView gameView = new GameView(); gameView.Show(); ((Window)o).Close();  });

        private ICommand reset;
        public ICommand Reset => reset = new RelayCommand(o => { GameView gameView = new GameView(); gameView.Show(); ((Window)o).Close(); });

        private ICommand exit;
        public ICommand Exit => exit = new RelayCommand(o => { ((Window)o).Close(); });


        public List<Button> keys = new List<Button>();
        private void Button_Click(object sender )
        {
            Button button = (Button)sender;

            if (_timer.IsEnabled == false)
            {
                recordWinLossForUser();
                CloseAction();

            }

            if (!word.Contains(button.Content.ToString()))
            {

                if (Index < info.Length - 1)
                {
                    Index++;
                    image = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/art/" + info.ElementAt(Index), UriKind.Absolute));
                    button.IsEnabled = false;
                    keys.Add(button);
                    OnPropertyChanged("Output");
                }
                counter++;
                display();
            }
            else
            {
                button.IsEnabled = false;
                keys.Add(button);
                refreshAnswer(button.Content.ToString());
                
            }
            if(result== categories.ElementAt(Nivel-1))
            {
                tbx2.Text = "";
                OnPropertyChanged("Tbx2");
                OnPropertyChanged("tbx2");
                NextLevel();
                refreshButtons();
            }


        }
        private void  recordWinLossForUser()
        {
            List<String> list = new List<string>();
            list.Add(userData.ElementAt(2));
            if (tbx4.Text == "Loss")
            {
                File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + user.Name + "_Lose.txt", list);


            }
            else
                if(tbx4.Text == "WIN")
            {
                File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + user.Name + "_Win.txt", list);

            }
        }
        private void loser()
        {
            CloseAction();
        }

        private void display()
        {
            if (counter == 1)
            {
                label1 = new Label();
                L1.Content = "X";
                OnPropertyChanged("L1");
            }
            if (counter == 2)
            {
                label2 = new Label();
                L2.Content = "X";
                OnPropertyChanged("L2");
            }
            if (counter == 3)
            {
                label3 = new Label();
                L3.Content = "X";
                OnPropertyChanged("L3");
            }
            if (counter == 4)
            {
                label4 = new Label();
                L4.Content = "X";
                OnPropertyChanged("L4");
            }
            if (counter == 5)
            {
                label5 = new Label();
                L5.Content = "X";
                OnPropertyChanged("L5");
            }
            if (counter == 6)
            {
                label6 = new Label();
                label6.Content = "X";
                OnPropertyChanged("L6");
                _timer.Stop();
                tbx4.Text = "Loss";
                recordWinLossForUser();
                OnPropertyChanged("tbx4");
                OnPropertyChanged("tbx4");
            }
        }

        private void refreshButtons()
        {
            for(int i =0;i< keys.Count;i++)
            {
                keys.ElementAt(i).IsEnabled = true;
                OnPropertyChanged(keys.ElementAt(i).Name);
            }
            keys.Clear();
        }

     
        private void refreshAnswer(string caracter)
        {
            string val = "";
            for (int i = 0; i < word.Length; i++)
            {

                if (word.ElementAt(i).ToString().Equals(caracter))
                {
                    val += caracter;
                }
                else
                {
                    val += result.ElementAt(i);
                }


            }
            result = val;
            tbx2.Text = val;
            OnPropertyChanged("Tbx2");
            OnPropertyChanged("tbx2");

        }

        private void NextLevel()
        {
            
            word = categories.ElementAt(Nivel);
            for (int i = 0; i < word.Length; i++)
            {
                if (word.ElementAt(i) == ' ')
                {
                    tbx2.Text += "  ";
                }
                else
                {
                    tbx2.Text += " _ ";
                }

            }
            result = tbx2.Text;
            Nivel =Nivel+1;
            tbx1.Text = Nivel.ToString();
            OnPropertyChanged("tbx1");
            OnPropertyChanged("Tbx1");
            
            if(Nivel == 6)
            {
                tbx4.Text = "WIN";
                recordWinLossForUser();
                OnPropertyChanged("tbx4");
                OnPropertyChanged("tbx4");
                _timer.Stop();
                return;
            }
            _time = TimeSpan.FromSeconds(30);
        }

        public List<String> userData { set; get; }
        public List<String> categories { set; get; }

        private ICommand stats;

        public ICommand Stats => stats = new RelayCommand(o => { Statistics statistics = new Statistics(); statistics.Show(); });

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
            user = new User { Name= userData.ElementAt(0), Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + userData.ElementAt(1), UriKind.Absolute)) };
        }

        public List<String> LoadCategories()
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../"+ userData.ElementAt(2)+".txt");
            List<String> t = new List<String>();

            while ((line = file.ReadLine()) != null)
            {
                t.Add(line);
            }
            file.Close();
            System.Console.ReadLine();
            return t;
        }

        Label label7 { set; get; }
        public Label Label7
        {
            set
            {
                label7 = value;
                OnPropertyChanged("Label7");
            }
            get
            {

                return label7;
            }
        }

    }


}

