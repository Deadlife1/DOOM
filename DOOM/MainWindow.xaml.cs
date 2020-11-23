using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DOOM.Pages;

namespace DOOM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// ACApplicationCategory ACApplication название 
    /// </summary>
    /// Id int идентификатор
    /// Title nvarchar(50)
    /// ACApplicationCategory_ID int
    /// перв ключ ACApplicationCategory id внеш ключ ACApplication ACApplicationCategory_ID
    /// https:// github.com/ ViperisPRO/ DemoTest
    /// UML это все что внутри таблицы 
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public MainWindow()
        {
            
            InitializeComponent();
            
            //подключение к бд
            

            var apps = Core.DB.ACApplication.ToList();
            _myElements = apps;
            this.DataContext = this;

            MainFrame.Navigate(new Pages.MainPage());

            ProfileButton.Click += ProfileButton_Click;

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ProfilePage());
        }

        private List<ACApplication> _myElements = new List<ACApplication>();

        public List<ACApplication> MyElements
        {
            get { return _myElements; }
            set { _myElements = value; }
        }


        private float _myNumberValue = 55;

        public event PropertyChangedEventHandler PropertyChanged;

        public float MyNumberValue
        {
            get
            {
                return _myNumberValue;
            }

            set
            {
                _myNumberValue = value;
            }
        }
        

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new SettingsWindow();
            w.Show();
        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Title = "{Binding Value, ElementName=MySlider}";
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ACApplication;
            var appPage = new ApplicationPage(item);
            MainFrame.Navigate(appPage);
        }

        private void AddAppButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddApplicationPage());
        }

        private void MainListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ACApplication;
            Core.DB.ACApplication.Remove(item);
            Core.DB.SaveChanges();
            MessageBox.Show(item.Title + "Удален");
        }
    }
}
    

