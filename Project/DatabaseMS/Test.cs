using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DatabaseMS
{
    public class Test
    {
        public User GetUser()
        {
            Console.WriteLine("Start");
            User user = null;
            using (var x = new DatabaseContext())
            {
                var find = x.Users.Find(2);
                if (find != null) user = find;
            }
            Console.WriteLine("Start");

            return user;
        }
    }
}
