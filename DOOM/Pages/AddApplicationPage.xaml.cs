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

namespace DOOM.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddApplicationPage.xaml
    /// </summary>
    public partial class AddApplicationPage : Page
    {
        public AddApplicationPage()
        {
            InitializeComponent();
            this.CurrentApplication = new ACApplication();
            this.DataContext = this;
        }
        public ACApplication CurrentApplication { get; set; }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Core.DB.ACApplication.Add(CurrentApplication);
            Core.DB.SaveChanges();
        }
    }
}
