using ShahanovApp.DataBase;
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
using System.Windows.Shapes;

namespace ShahanovApp.Pages.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmploye.xaml
    /// </summary>
    public partial class AddEditEmploye : Window
    {
        public AddEditEmploye()
        {
            InitializeComponent();
            cmbPost.ItemsSource = Service.PostService.GetPostInfo();
            cmbDep.ItemsSource = Service.DepartamentService.GetDepartamentInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = Service.EmployeService.AddEmploye(FirstNameTxb.Text, SecondNameTxb.Text, PatronymicNameTxb.Text, cmbDep.SelectedItem as Departament, cmbPost.SelectedItem as Post, Convert.ToInt32(StajTxb.Text));
          
                InfoPage.dataGridemp.ItemsSource = null;
                InfoPage.dataGridemp.ItemsSource = Service.EmployeService.GetEmployeInfo();
            
            MessageBox.Show(result);
        }
    }
}
