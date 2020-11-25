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
using Demo3.Pages;

namespace Demo3
{
  
    public partial class MainWindow : Window 
    {


        public MainWindow()
        {
            
            InitializeComponent();
            
            //подключение к бд
            

           
           
            this.DataContext = this;

            MainFrame.Navigate(new Pages.MainPage());

            ProfileButton.Click += ProfileButton_Click;

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ProfilePage());
        }

        
         

        private float _myNumberValue = 55;
        private readonly object Demo3;

        public event PropertyChangedEventHandler Demo;

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
           
          
        }

        private void AddAppButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddApplicationPage());
        }

        private void MainListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
    

