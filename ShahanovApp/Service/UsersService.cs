using ShahanovApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanovApp.Service
{
    internal class UsersService
    {
        public static bool IsAuthorize = false;
        public static Users FindUser(string login, string password)
        {
            ShahanovEntities context = new ShahanovEntities();
            var user = context.Users.FirstOrDefault(p => p.UserLogin == login && p.UserPassword == password);
            if(user != null)
            {
                IsAuthorize = true;
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
