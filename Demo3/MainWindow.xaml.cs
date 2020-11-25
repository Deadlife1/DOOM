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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window, INotifyPropertyChange


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