using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class UserStore
    {
        public static List<User> GetAllUser()
        {
            List<User> users = new List<User>();

            users.Add(new User("user123", "pass123"));
            users.Add(new User("Rayba", "password"));
            users.Add(new User("Netaji", "123456"));
            users.Add(new User("Raya", "Raya123"));
            return users;
        }
    }
}
