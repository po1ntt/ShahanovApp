using ShahanovApp.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanovApp.Service
{
    internal class PostService
    {
        public static ObservableCollection<Post> GetPostInfo()
        {
            ShahanovEntities context = new ShahanovEntities();
            var Collection = new ObservableCollection<Post>();
            var items = context.Post.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}
