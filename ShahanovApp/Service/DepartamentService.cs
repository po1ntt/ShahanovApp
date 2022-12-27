using ShahanovApp.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanovApp.Service
{
    internal class DepartamentService
    {
        public static ObservableCollection<Departament> GetDepartamentInfo()
        {
            ShahanovEntities context = new ShahanovEntities();
            var Collection = new ObservableCollection<Departament>();
            var items = context.Departament.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}
