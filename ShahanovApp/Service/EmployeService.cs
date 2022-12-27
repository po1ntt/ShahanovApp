using ShahanovApp.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShahanovApp.Pages;

namespace ShahanovApp.Service
{
    internal class EmployeService
    {
        public static ObservableCollection<Employe> GetEmployeInfo()
        {
            ShahanovEntities context = new ShahanovEntities();
            var Collection = new ObservableCollection<Employe>();
            var items = context.Employe.ToList();
            foreach (var item in items)
            {
                item.FIO = $"{item.SecondName} {item.FirstName} {item.Patronymic}";
                Collection.Add(item);
            }
            return Collection;
        }
        public static ObservableCollection<Employe> GetEmployeInfo(string namedep)
        {
            ShahanovEntities context = new ShahanovEntities();
            var Collection = new ObservableCollection<Employe>();
            var items = context.Employe.ToList().Where(p=> p.Departament.NameDepartament == namedep);
            foreach (var item in items)
            {
                item.FIO = $"{item.SecondName} {item.FirstName} {item.Patronymic}";
                Collection.Add(item);
            }
            return Collection;
        }
        public static string DeleteEmploye(Employe emp)
        {
            string result = "Ошибка";
            using (ShahanovEntities context = new ShahanovEntities())
            {
                var emptodelete = context.Employe.FirstOrDefault(p => p.id_emp == emp.id_emp);
                if (emptodelete != null)
                {
                    context.Employe.Remove(emptodelete);

                    context.SaveChanges();

                    result = "Cотрудник с фамилией " + emp.SecondName + " успешно удален";
                }
                else
                {
                    result = "Ошибка";
                }
            }
            return result;
        }
        public static string AddEmploye(string firstname, string secondname, string patronymic, Departament departament, Post post, int staj)
        {
            string result = "Ошибка";
            Random random = new Random();

            using (ShahanovEntities context = new ShahanovEntities())
            {
               
                    context.Employe.Add(new Employe
                    {
                       id_emp = random.Next(),
                       FirstName = firstname,
                       SecondName = secondname,
                       Patronymic = patronymic,
                       dep_id = departament.id_dep,
                       Experience = staj,
                       post_id = post.id_post

                    });;
                    result = "Новый сотрудник успешно добавлен";
              
                context.SaveChanges();
                
            }
            return result;
        }
    }
}
