using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Spanzuratoarea.Model;
using System.Drawing;
using Spanzuratoarea.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spanzuratoarea.Commands;
using System.Windows;
using System.IO;
using System.Windows.Controls;

namespace Spanzuratoarea.ViewModel
{
    class SingInViewModel:BaseVM
    {
        public ObservableCollection<User> items { get; set; }
        private List<String> userData { get; set; }
        //public ObservableCollection<User> Items { get; set; }
        private String userName;
        public bool val;
        public SingInViewModel()
        {
            items = new ObservableCollection<User>();
            items = LoadUsers();
            //items.Add(new User() { Name = "Jerry", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/jerry.jpg", UriKind.Absolute)) });
            //items.Add(new User() { Name = "Tom", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/tom.jpg", UriKind.Absolute)) });
            //items.Add(new User() { Name = "Scooby Doo", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/scooby.jpg", UriKind.Absolute)) });
            //items.Add(new User() { Name = "Shaggy", Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/shaggy.jpg", UriKind.Absolute)) });
            //this.startC = new StartCommand(new GameView());
        }

        public ObservableCollection<User> LoadUsers()
        {

            userData = new List<string>();
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../Users.txt");
            ObservableCollection<User> t = new ObservableCollection<User>();
            String name;
            String img;
           

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                name = line;
                line = file.ReadLine();
                System.Console.WriteLine(line);
                img = line;
                userData.Add(name);
                userData.Add(img);
                t.Add(new User() { Name = name, Img = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + img, UriKind.Absolute)) });

            }

            file.Close();
            System.Console.ReadLine();

            return t;
        }
        private bool canExecuteCommand = false;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }
        String img;
        public void RemoveUser(ListView listView)
        {//numele e pe poz*2-1 poza pe poz*2
          
            int poz = listView.SelectedIndex;
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + userData.ElementAt(poz * 2) + "_Win.txt");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + userData.ElementAt(poz * 2) + "_Lose.txt");
            img = userData.ElementAt(poz * 2 + 1);
            items.RemoveAt(poz);
            userData.RemoveAt(poz * 2);
            userData.RemoveAt(poz * 2 );
            
            //listView.ItemsSource = null;

            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            System.IO.File.WriteAllText(System.IO.Path.Combine(docPath, "Users.txt"), string.Empty);
            File.AppendAllLines(System.IO.Path.Combine(docPath, "Users.txt"), userData);
            
            
            OnPropertyChanged("items");
            

        }
        public Action CloseAction { get; set; }
        public void ModifyUser(ListView listView)
        {
            int poz = listView.SelectedIndex;
            
            String name = userData.ElementAt(poz * 2);
            String img = userData.ElementAt(poz * 2+1);
            List<String> userL = new List<string>();
            userL.Add(name);
            userL.Add(img);

            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            System.IO.File.WriteAllText(System.IO.Path.Combine(docPath, "CurentUser.txt"), string.Empty);
            File.AppendAllLines(System.IO.Path.Combine(docPath, "CurentUser.txt"), userL);

            //File.Delete(AppDomain.CurrentDomain.BaseDirectory + img);
            OnPropertyChanged("items");

        }


        private ICommand removeU;

        public ICommand RemoveU => removeU = new RelayCommand(o => { RemoveUser((ListView)o);  });


        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close() );


        public StartCommand startC { get; set; }




        //public ICommand Start {
        //    get
        //    {
        //        start = startC;
        //        return start;
        //    }
        //    set
        //    {
        //        startC = new StartCommand(new GameView());

        //    }
        //}
        private ICommand start;
        public ICommand Start => start = new RelayCommand(o => { ModifyUser((ListView)o); PlayGameView playGameView = new PlayGameView(); playGameView.Show();  });




        private ICommand newUser;
        public ICommand NewUserCommand => newUser = new RelayCommand(o => { NewUser userView = new NewUser(); userView.Show(); ((Window)o).Close();  });




    }
   
}
