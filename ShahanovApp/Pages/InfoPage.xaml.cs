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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShahanovApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public static DataGrid dataGridemp;
        public static ComboBox cmbemp;
        public InfoPage()
        {
            InitializeComponent();
            EmployeDgData.ItemsSource = Service.EmployeService.GetEmployeInfo();
            DepartamentDgData.ItemsSource = Service.DepartamentService.GetDepartamentInfo();
            PostDgData.ItemsSource = Service.PostService.GetPostInfo();
            List<Departament> collection = Service.DepartamentService.GetDepartamentInfo().ToList();
            dataGridemp = EmployeDgData;
            СomboDeps.Items.Add("Не выбрано");
            foreach(var item in collection)
            {
                СomboDeps.Items.Add(item.NameDepartament);
            }
            СomboDeps.SelectedIndex = 0;
            cmbemp = СomboDeps;

        }

        private void СomboDeps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (СomboDeps.SelectedIndex != 0)
            {
                ShahanovEntities context = new ShahanovEntities();
                EmployeDgData.ItemsSource = null;
                Departament ge = context.Departament.FirstOrDefault(p => p.id_dep == СomboDeps.SelectedIndex);
                EmployeDgData.ItemsSource = Service.EmployeService.GetEmployeInfo(ge.NameDepartament);
            }
            else
            {
                EmployeDgData.ItemsSource = null;
                EmployeDgData.ItemsSource = Service.EmployeService.GetEmployeInfo();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeDgData.SelectedItem != null)
            {
                if (MessageBox.Show("После удаления восстновления записи не возможно", "Удалить запись?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string result = Service.EmployeService.DeleteEmploye(EmployeDgData.SelectedItem as Employe);
                    if(СomboDeps.SelectedIndex != 0)
                    {
                        СomboDeps.SelectedIndex = 0;

                    }
                    else
                    {
                        EmployeDgData.ItemsSource = null;
                        EmployeDgData.ItemsSource = Service.EmployeService.GetEmployeInfo();
                    }
                    MessageBox.Show(result);
                }


            }
        }
    }
}
