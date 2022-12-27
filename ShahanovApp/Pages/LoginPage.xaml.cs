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

namespace ShahanovApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userdata = Service.UsersService.FindUser(LoginTxb.Text, PasswordTxb.Password);
            if(userdata != null)
            {

                MessageBox.Show("Авторизация прошла успешно!");
                Service.NavService.NavClass.Navigate(new InfoPage());
            }
            else
            {
                MessageBox.Show("Не верен логин или пароль");
            }
        }
    }
}
