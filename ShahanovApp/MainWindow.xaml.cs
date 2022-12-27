using ShahanovApp.Pages;
using ShahanovApp.Pages.Windows;
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

namespace ShahanovApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Service.NavService.NavClass = Mainframe;
            Service.NavService.NavClass.Navigate(new LoginPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Service.UsersService.IsAuthorize == true)
            {
                Service.NavService.OpenCenterPosAndOpen(new AddEditEmploye());

            }
            else
            {
                MessageBox.Show("Авторизуйся в приложении");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Service.UsersService.IsAuthorize ==false)
            {
                MessageBox.Show("Вы не авторизованы");
            }
            else
            {
                Service.UsersService.IsAuthorize = false;
                Service.NavService.NavClass.Navigate(new LoginPage());
            }

          
        }
    }
}
