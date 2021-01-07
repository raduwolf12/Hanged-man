using Spanzuratoarea.Commands;
using Spanzuratoarea.Model;
using Spanzuratoarea.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Spanzuratoarea.ViewModel
{
    class PlayGameViewModel:BaseVM
    {
        public User user
        { set; get; }

        List<String> categories { set; get; }
        List<String> userData { set; get; }

        Label label { set; get; }
        public Label Label
        {
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
            get
            {
                
                return label;
            }
        }
        TextBox textBox { set; get; }
        public TextBox TextBo
        {

            set
            {
                textBox = value;
                OnPropertyChanged("TextBo");
            }
            get
            {

                return textBox;
            }
        }

        public PlayGameViewModel()
        {
            label = new Label();
            user = new User();
            userData = new List<string>();
            user = LoadUser();
            label.Content = user.Name;
            textBox = new TextBox();

        }
        private ICommand start;
        public ICommand Start => start = new RelayCommand(o => { PlayGameView playGameView = new PlayGameView(); playGameView.Show();  Label.Content = "test"+GetName(o); OnPropertyChanged("Label"); });
        public String GetName(object obj)
        {
            
            String val =obj as String;
            Label.Content = val;
            OnPropertyChanged("Label");
            return val;

        }

        public User LoadUser()
        {

            
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../CurentUser.txt");
            List<User> t = new List<User>();
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
            if (t.Count >0)
            {
                return t.ElementAt(0);
            }
            else
            {
                return null;
            }
        }

        public void data(String param)
        {
            if(userData.Count()>2)
            {
                userData.Remove(TextBo.Text);
                userData.Add(param);
            }
            else
            {
                userData.Add(param);
            }
            RefreshFile();
        }

        public void RefreshFile()
        {
            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            System.IO.File.WriteAllText(System.IO.Path.Combine(docPath, "CurentUserData.txt"), string.Empty);
            File.AppendAllLines(System.IO.Path.Combine(docPath, "CurentUserData.txt"), userData);
        }

        public List<String> LoadCategories(MenuItem menuItem)
        {
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("../../"+ menuItem.Header.ToString()+ ".txt");
            List<String> t = new List<String>();

            while ((line = file.ReadLine()) != null)
            {
                t.Add(line);
            }
            file.Close();
            System.Console.ReadLine();
            return t;
        }

        private ICommand load;
        public ICommand Load => load = new RelayCommand(o => { data(((MenuItem)o).Header.ToString()); TextBo.Text = ((MenuItem)o).Header.ToString(); OnPropertyChanged("TextBox");  categories = LoadCategories((MenuItem)o);  });

        private ICommand about;

        public ICommand About => about = new RelayCommand(o => { StudentAbout studentAbout = new StudentAbout(); studentAbout.Show(); });


        private ICommand stats;

        public ICommand Stats => stats = new RelayCommand(o => { Statistics statistics = new Statistics(); statistics.Show(); });



    }
}
