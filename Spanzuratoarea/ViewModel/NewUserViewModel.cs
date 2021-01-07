using Microsoft.Win32;
using Spanzuratoarea.Commands;
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
    class NewUserViewModel : BaseVM
    {

        private DirectoryInfo dirInfo;
        private FileInfo[] info;
        private int Index;
        private Uri lastUri;
        //public ObservableCollection<BitmapImage> image { set; get; }

        private BitmapImage output { set; get; }
        public BitmapImage Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }
        public Action CloseAction { get; set; }

        public NewUserViewModel()
        {
            dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Images");
            info = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            //image = new ObservableCollection<BitmapImage>();
            //image.Add(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(0), UriKind.Absolute)));
            output = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(0), UriKind.Absolute));

            lastUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(0));
            Index = 0;
        }

        public void CreateUser(String name)
        {
            List<String> list = new List<string>();
            //String name = "test";
            String img = getImgUrl();
            list.Add(name);
            list.Add(img);
            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            File.AppendAllLines(System.IO.Path.Combine(docPath, "Users.txt"), list);
            File.CreateText(AppDomain.CurrentDomain.BaseDirectory + name + "_Win.txt");
            File.CreateText(AppDomain.CurrentDomain.BaseDirectory + name + "_Lose.txt");
        }
        private ICommand create;

        public ICommand Create => create = new RelayCommand(o => { CreateUser(((TextBox)(o)).Text); OnPropertyChanged("Exit");  SingInWindowView obj = new SingInWindowView(); obj.Show(); CloseAction(); });

        public String getImgUrl()
        {
            //BitmapImage im = image.ElementAt(0);
            //String fileName = GetVal(im.ToString());

            String fileName = GetVal(output.ToString());

            string sourceFile = System.IO.Path.Combine(lastUri.LocalPath.ToString(), "");
            string destFile = Environment.CurrentDirectory + "/" + fileName;
            //createFile(destFile);

            //File.Copy(sourceFile, destFile,true);

            FileInfo fi = new FileInfo(sourceFile);
            fi.CopyTo(destFile, true); // existing file will be overwritten

            return fileName;
        }
        //public void createFile(string destFile)
        //{
        //    File.Create(destFile);
        //}
        public String GetVal(String na)
        {
            String val = "";
            for (int i = na.Length - 1; i > 0; i--)
            {
                if (na.ElementAt(i) == '/')
                {
                    break;
                }
                val = na.ElementAt(i) + val;


            }
            return val;

        }

        private BitmapImage uploadP()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);

                lastUri = fileUri;

                //image.Clear();
                //image.Add(new BitmapImage(fileUri));
                output = new BitmapImage(fileUri);
                OnPropertyChanged("output");
                OnPropertyChanged("Output");
            }
            return output;
        }

        private ICommand upload;
        public ICommand Upload => upload = new RelayCommand(o => { output = uploadP(); });


        public BitmapImage rightArrow()
        {
            if (Index < info.Length - 8 )
            {
                Index++;
                //image.Clear();
                //image.Add(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute)));
                output = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute));
                lastUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index));
                OnPropertyChanged("Output");
            }
            return output;
        }

        public BitmapImage leftArrow()
        {
            if (Index > 0)
            {
                Index--;
                //image.Clear();
                //image.Add(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute)));
                output = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index), UriKind.Absolute));
                lastUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + info.ElementAt(Index));
                OnPropertyChanged("Output");
            }
            return output;
        }
        private ICommand right;
        public ICommand Right => right = new RelayCommand(o => { output = rightArrow(); });

        private ICommand left;
        public ICommand Left=> left = new RelayCommand(o => { output = leftArrow(); });


        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close());
    }
}
